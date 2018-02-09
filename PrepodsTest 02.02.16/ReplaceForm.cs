using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrepodsTest
{
    public partial class ReplaceForm : Form
    {
        private System.Windows.Forms.DataGridViewComboBoxColumn listPrepods;
        private System.Windows.Forms.DataGridViewButtonColumn DoReplace;
        Connector myCon = new Connector();
        public ReplaceForm()
        {
            InitializeComponent();
        }

        private void ReplaceForm_Load(object sender, EventArgs e)
        {

            // Retrieve the working rectangle from the Screen class
            // using the PrimaryScreen and the WorkingArea properties.
            System.Drawing.Rectangle workingRectangle =
                Screen.PrimaryScreen.WorkingArea;

            // Set the size of the form slightly less than size of 
            // working rectangle.
            this.Size = new System.Drawing.Size(
                workingRectangle.Width - 10, workingRectangle.Height - 10);

            // Set the location so the entire form is visible.
            this.Location = new System.Drawing.Point(5, 5);
            
            
            if (Program.useEvenWeeks == false)
            {
                checkBoxEvenWeek.Visible = false;
            }
            else
            {
                checkBoxEvenWeek.Visible = true;
            }
            dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dgvCombo_DataError);
            myCon.Initialize();
            List<string> prepods =myCon.SelectPrepodsToList();
            comboBoxprepodReplace.Items.AddRange( prepods.ToArray() );

        }
        
        int _PrepodId = 0;
        int _daynum = 0;
        private void buttonReplace_Click(object sender, EventArgs e)
        {
            //Подобрать замены
            if (textBoxNumDay.Text != "")
            {
                try
                {
                    int dayNum = Convert.ToInt32(textBoxNumDay.Text);
                    _daynum = dayNum;
                    string prepName = comboBoxprepodReplace.Items[comboBoxprepodReplace.SelectedIndex].ToString();
                    //int idPrepod = myCon.SelectPrepodsIdByName(
                    myCon.Initialize();
                    int prepodId = 0;


                    //prepodsList - fioBday
                    if (prepName.Contains("("))
                    {
                        string prepDate = "";
                        string[] subs1 = prepName.Split('(');
                        string prepNameFull = subs1[0].Trim();
                        prepDate = subs1[1].Replace("(", "").Replace(")", "").Trim();
                        myCon.Initialize();
                        prepodId = myCon.GetPrepodId(prepNameFull, prepDate);
                    }
                    else
                    {
                        myCon.Initialize();
                        prepodId = myCon.GetPrepodId(prepName);
                    }
                    _PrepodId = prepodId;
                    BindingSource bSource = null;
                    if (Program.useEvenWeeks)
                    {
                        bSource = myCon.SelectPrepodLessonsToGrid(dayNum, prepodId, true , checkBoxEvenWeek.Checked);
                    }
                    else
                    {
                        bSource = myCon.SelectPrepodLessonsToGrid(dayNum, prepodId);
                    }
                    dataGridView1.DataSource = bSource;
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        string name = col.Name;
                        string ht = col.HeaderText;
                        if (name == "id" || name == "idKlass" || name == "idSpec" || name == "idPrepod" || name == "idRoom" || name == "isSubGroup" || name == "numSubGroup")
                        {
                            col.ReadOnly = false;
                            col.Visible = false;
                        }
                        if (name == "numSubGroup")
                        {
                            col.ReadOnly = false;
                            col.Visible = true;
                            //col.Width = 1;
                            col.HeaderText = "Подгруппа №";
                        }
                        if (name == "lessonNumber")
                        {
                            col.ReadOnly = false;
                            col.Visible = true;
                            //col.Width = 1;
                            col.HeaderText = "Урок №";
                        }
                        if (name == "klassnameyear")
                        {
                            col.ReadOnly = false;
                            col.Visible = true;
                            //col.Width = 1;
                            col.HeaderText = "Класс";
                        }
                        if (name == "isSubGroup")
                        {
                            col.ReadOnly = false;
                            col.Visible = true;
                            //col.Width = 1;
                            col.HeaderText = "Подгруппа";
                        }
                        if (name == "Roomname")
                        {
                            col.ReadOnly = false;
                            col.Visible = true;
                            //col.Width = 1;
                            col.HeaderText = "Аудитория №";
                        }
                        if (name == "isEven")
                        {
                            if (Program.useEvenWeeks == false)
                            {
                                col.Visible = false;
                                col.ReadOnly = true;
                            }
                            else
                            {
                                col.Visible = true;
                                col.ReadOnly = false;
                            }
                            col.HeaderText = "Чет. нед.";
                            col.ReadOnly = true;
                        }

                        col.ReadOnly = true;
                    }
                    if (dataGridView1.Columns.Contains("PrepsForReplaceCurLesson") == false)
                    {
                        addReplaceListColumn();
                    }
                    else
                    {
                        dataGridView1.Columns.Remove("PrepsForReplaceCurLesson");
                        addReplaceListColumn();
                    }
                    FillReplacementsForEachLesson();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //throw;
                }
            }
        }
        /// <summary>
        /// ГЛАВНЫЙ - подбор замен для каждого урока невышедшего препода
        /// </summary>
        void FillReplacementsForEachLesson()
        {
            
            foreach (DataGridViewRow currow in dataGridView1.Rows)
            {
                myCon.Initialize();
                object curLessonNumberV = currow.Cells["lessonNumber"].Value;
                if (curLessonNumberV!=DBNull.Value && curLessonNumberV!=null )
                {
                    int curLesson = Convert.ToInt32(curLessonNumberV.ToString() );
                    int specId = Convert.ToInt32(currow.Cells["idSpec"].Value.ToString());
                    int idKlass = Convert.ToInt32(currow.Cells["idKlass"].Value.ToString());
                    
                    List<string> prepodsIds = myCon.SelectIdsPrepodsClassToGridForReplace(_daynum, curLesson, _PrepodId);
                    myCon.Initialize();
                    string specNameNoSemester = myCon.GetSpecName(specId);
                    
                    List<string> prepodsForReplace = new List<string>();
                    Dictionary<string, int> prepodsWithCoef = new Dictionary<string, int>();

                    foreach (string prepId in prepodsIds)
                    {
                        myCon.Initialize();
                        string curName = myCon.SelectPrepodsNameById(prepId);

                        GetCoefAppliableClass coef = GetCoefAppliable(prepId, specId, idKlass, specNameNoSemester, curLesson);
                        //curName = curName + coef.coef+")"+coef.coefHome;
                        prepodsWithCoef.Add(curName + " ["+coef.coef + "] " + coef.coefHome, coef.coef);    
                        
                    }
                    //сортировка преподов по коэффициенту
                    var res = prepodsWithCoef.OrderByDescending(pr => pr.Value);

                    //заполним список
                    foreach (var kyavaluepair in res)
                    {
                        prepodsForReplace.Add(kyavaluepair.Key.ToString());
                        
                    }
                    
                    DataGridViewComboBoxCell subCellPrepsForReplaceCurLesson = (DataGridViewComboBoxCell)currow.Cells["PrepsForReplaceCurLesson"];
                    //subCellPrepsForReplaceCurLesson.Items = new DataGridViewComboBoxCell.ObjectCollection(subCellPrepsForReplaceCurLesson);
                    foreach (string sprep in prepodsForReplace)
                    {
                        subCellPrepsForReplaceCurLesson.Items.AddRange(new object[] { sprep });
                    }
                    //foreach (var item in prepodsForReplace)
                    //{
                    //    subCellPrepsForReplaceCurLesson.Items.Add(item.ToString());
                    //}
                }
            }

        }
        class GetCoefAppliableClass
        {
            public int coef;
            public string coefHome;
        }
        private GetCoefAppliableClass GetCoefAppliable(string prepId, int specId, int idKlass, string specNameNoSemester, int curLesson)
        {
            string result = "";
            //1)коэффициент по спеке
            myCon.Initialize();
            int CoefPrepodSpec = myCon.CoefPrepodSpec(prepId, specId, specNameNoSemester);
            //2) коэффициент дома или в лицее
            
            myCon.Initialize();
            string CoefHome = myCon.CoefHome(prepId, _daynum, curLesson, Program.useEvenWeeks, checkBoxEvenWeek.Checked);
            //3)количество замен, сделанных ранее вообще (в этом месяце)
            myCon.Initialize();
            List<string> ReplacementsInMonth = myCon.GetReplacementsInMonth(prepId);
            //TODO: ОБРАТНАЯ - чем больше замен тем хуже
            int CountReplacementsInMonth = (-1)*ReplacementsInMonth.Count;
            //4)количество уроков и замен у этого класса в этом месяцу
            myCon.Initialize();
            //колво замен у этого класса (ПРЯМОЕ - чем больше замен у этого класса тем лучше)
            List<string> ReplacementsInMonthForKlass = myCon.GetReplacementsInMonth(prepId, idKlass);            
            int countReplacementsForKlass = ReplacementsInMonthForKlass.Count;

            //4.1)ведет ли этот препод по расписанию что-то у этого класса
            myCon.Initialize();
            List<string> ShedulePrepForKlass = myCon.GetShedulePrepForKlass(prepId, idKlass);
            int countShedulePrepForKlass = ShedulePrepForKlass.Count;

            int totalCoef4 = countReplacementsForKlass + countShedulePrepForKlass;
            //ФОРМУЛА с "весами" каждого коэффициента (какой более важен)
            int coefResult = CoefPrepodSpec * 5 + CountReplacementsInMonth * 4 + totalCoef4 * 3;
            var ca = new GetCoefAppliableClass();
            ca.coef = coefResult;
            ca.coefHome = CoefHome;
            return ca;
            //" _есть спека=" + prepodHasCurSpec + "; похожаяСпекаКолво=" + countSpecsWithSameName + "; сколькоЗамен=" + countReplacementsForKlass + "; сколькоПоРасписанию=" + countShedulePrepForKlass+";"; 
        }
        
        private void addReplaceListColumn()
        {
            this.listPrepods = new System.Windows.Forms.DataGridViewComboBoxColumn();

            // 
            // list
            // 
            myCon.Initialize();
            List<ListKlasses> lst = myCon.SelectKlassesToList();
            this.listPrepods.HeaderText = "Преподаватели на замену";
            this.listPrepods.Width = 450;
            


            this.listPrepods.Name = "PrepsForReplaceCurLesson";
            this.dataGridView1.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[] { this.listPrepods });
        }
        void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here)
        }

        private void buttonFillOthcet_Click(object sender, EventArgs e)
        {
            //int currowind = ind;
            //проверим заполненность
            bool allFilled = true;
            foreach (DataGridViewRow currow in dataGridView1.Rows)
            {
                object idVal = currow.Cells["id"].Value;
                if (idVal != DBNull.Value && idVal != null)
                {
                    object PrepFioFullVal = currow.Cells["PrepsForReplaceCurLesson"].Value;
                    if (PrepFioFullVal == null || string.IsNullOrEmpty(PrepFioFullVal.ToString()))
                    {
                        allFilled = false;
                    }
                }
                
            }
            if (!allFilled)
                MessageBox.Show("Не всё заполнено!");

            if (allFilled)
            {
                int inserted = 0;
                foreach (DataGridViewRow currow in dataGridView1.Rows)
                {

                    object PrepFioFullVal = currow.Cells["PrepsForReplaceCurLesson"].Value;
                    int prepodId = 0;
                    if (PrepFioFullVal != DBNull.Value && PrepFioFullVal != null)
                    {

                        string PrepFioFull = PrepFioFullVal.ToString();//
                        PrepFioFull = PrepFioFull.Substring(0, PrepFioFull.IndexOf("[")).Trim();
                        //prepodsList - fioBday
                        if (PrepFioFull.Contains("("))
                        {
                            string prepDate = "";
                            string[] subs1 = PrepFioFull.Split('(');
                            string prepNameFull = subs1[0].Trim();
                            prepDate = subs1[1].Replace("(", "").Replace(")", "").Trim();
                            myCon.Initialize();
                            prepodId = myCon.GetPrepodId(prepNameFull, prepDate);
                        }
                        else
                        {
                            myCon.Initialize();
                            prepodId = myCon.GetPrepodId(PrepFioFull);
                        }
                    }
                    if (prepodId!=0)
                    {
                        inserted++;
                        myCon.Initialize();
                        string idKlass = currow.Cells["idKlass"].Value.ToString();
                        string isSubGroup = Convert.ToInt32(currow.Cells["isSubGroup"].Value).ToString();
                        string numSubGroup = currow.Cells["numSubGroup"].Value.ToString();
                        string now = DateTime.Now.ToString("yyyy-MM-dd");
                        
                        int specId = Convert.ToInt32(currow.Cells["idSpec"].Value.ToString());
                        int roomId = Convert.ToInt32(currow.Cells["idRoom"].Value.ToString());

                        myCon.InsertOtchet(prepodId, idKlass, isSubGroup, numSubGroup, _PrepodId, now, _daynum, specId, roomId);
                    }

                }
                MessageBox.Show("Добавлено записей:" + (inserted).ToString());
                //Clear
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
            }
            //DataGridViewRow currow = dataGridView1.Rows;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
