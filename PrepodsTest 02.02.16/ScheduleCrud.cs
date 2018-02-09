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
    public partial class ScheduleCrud : Form
    {

        int selectCounter = 0;
        void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here)
        }
        private System.Windows.Forms.DataGridViewComboBoxColumn listKlasses;
        private System.Windows.Forms.DataGridViewComboBoxColumn listPrepods;
        private System.Windows.Forms.DataGridViewComboBoxColumn listRooms;
        private System.Windows.Forms.DataGridViewComboBoxColumn listSpecs;
        /// <summary>
        /// в таблице: подгруппа - число. 0-нет, 1-первая,2-вторая. в списке - строки "все", "1", "2".
        /// </summary>
        private System.Windows.Forms.DataGridViewComboBoxColumn listSubGroups;
        private string DayName(int daynumber)
        {
            string ret = "";
            switch (daynumber)
            {
                case 1: ret = "понедельник"; break;
                case 2: ret = "вторник"; break;
                case 3: ret = "среда"; break;
                case 4: ret = "четверг"; break;
                case 5: ret = "пятница"; break;
                case 6: ret = "суббота"; break;
                case 7: ret = "воскресенье"; break;
                default: ret = "неизвестно";
                    break;
            }

            return ret;
        }
        Connector myCon = new Connector();
        public ScheduleCrud()
        {
            InitializeComponent();
            dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dgvCombo_DataError);
        }

   

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            selectTOGrid();
        }
        void selectTOGrid()
        {

            //object a = null; 
            //MessageBox.Show("a="+a.ToString());
            myCon.Initialize();
            BindingSource bSource = myCon.SelectSheduleToGrid();
            dataGridView1.DataSource = bSource;
            //shedule columns:
            //schedule.id,idKlass,idPrepod,idRoom,isSubGroup, numDayOfWeek,nameDayOfWeek,
            //numSubGroup,isEven,isPair
            //klassnameyear prepodFIO
            //RoomName
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                string name = col.Name;
                string ht = col.HeaderText;
                if (name == "id" || name == "idKlass" || name == "idPrepod" || name == "idRoom" || name == "isSubGroup" || name == "idSpec")
                {
                    col.ReadOnly = true;
                    col.Visible = false;
                    col.Width = 30;
                }

                //TODO: isSubGroup - выпадающий список 1,2, весь класс               
                if (name == "numSubGroup")
                {
                    col.ReadOnly = true;
                    col.Visible = false;
                    //col.Width = 1;
                    col.HeaderText = "Подгруппа №";
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
                    col.HeaderText = "Четная неделя";
                }
                if (name == "klassnameyear")
                {
                    col.ReadOnly = true;
                    col.Visible = false;
                    //col.Width = 1;
                    col.HeaderText = "Класс-GOD-111";
                }
                if (name == "prepodFIO")
                {
                    col.ReadOnly = true;
                    col.Visible = false;
                    col.Width = 30;
                    //col.HeaderText = "Преподаватель";
                }
                if (name == "RoomName")
                {
                    col.ReadOnly = true;
                    col.Visible = false;
                    col.Width = 30;
                    //col.HeaderText = "Аудитория";
                }
                if (name == "isPair")
                {
                    col.HeaderText = "Пара";
                }
                if (name == "lessonNumber")
                {
                    col.HeaderText = "№ урока";
                    col.Width = 80;
                }

                if (name == "nameDayOfWeek")
                {
                    col.HeaderText = "День недели";
                    col.ReadOnly = true;

                }
                if (name == "numDayOfWeek")
                {
                    col.HeaderText = "Номер дня";
                }

                if (name == "Specs")
                {
                    col.HeaderText = "Специализации";
                }

                //MessageBox.Show(name+"  ht="+ht);
            }

            //list klasses
            //каждый раз при селекте классы могут измениться, заново заполнить колонку
            if (dataGridView1.Columns.Contains("Klass_Year_222") == false)
            {
                addKlassList();
            }
            else
            {
                //dataGridView1.Columns.Remove("Klass_Year_222");
                //addKlassList();
            }
            if (dataGridView1.Columns.Contains("subGroupList") == false)
            {
                addSubGroupList();
            }
            else
            {
                //dataGridView1.Columns.Remove("subGroupList");
                //addSubGroupList();
            }

            if (dataGridView1.Columns.Contains("prepodsList") == false)
            {
                addprepodsList();
            }
            else
            {
                // dataGridView1.Columns.Remove("prepodsList"); 
                //addprepodsList();
            }

            if (dataGridView1.Columns.Contains("roomsList") == false)
            {
                addRoomsList();
            }
            else
            {
                //dataGridView1.Columns.Remove("roomsList");
                //addRoomsList();
            }


            if (dataGridView1.Columns.Contains("specsList") == false)
            {
                addSpecsList();
            }
            else
            {
                //dataGridView1.Columns.Remove("specsList");
                //addSpecsList();
            }
            if (selectCounter == 0)
            {
                SetDayName_SubGrup_AllRows();
            }
            else
            {
                SetDayName_Only();
            }
            selectCounter++;
        }

        void addKlassList()
        {
            this.listKlasses = new System.Windows.Forms.DataGridViewComboBoxColumn();

            // 
            // list
            // 
            myCon.Initialize();
            List<ListKlasses> lst = myCon.SelectKlassesToList();
            this.listKlasses.HeaderText = "Класс-ГОД";

            foreach (var klass in lst)
            {
                this.listKlasses.Items.AddRange(new object[] { klass.ToString() });
            }


            this.listKlasses.Name = "Klass_Year_222";
            this.dataGridView1.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[] { this.listKlasses });
        }
        void addprepodsList()
        {
            this.listPrepods = new System.Windows.Forms.DataGridViewComboBoxColumn();

            // 
            // list
            // 
            myCon.Initialize();
            List<string> lst = myCon.SelectPrepodsToList();
            this.listPrepods.HeaderText = "Преподаватели";

            foreach (string prep in lst)
            {
                this.listPrepods.Items.AddRange(new object[] { prep });
            }

            this.listPrepods.Width = 200;
            this.listPrepods.Name = "prepodsList";
            this.dataGridView1.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[] { this.listPrepods });
        }
        void addRoomsList()
        {
            this.listRooms = new System.Windows.Forms.DataGridViewComboBoxColumn();

            // 
            // list
            // 
            myCon.Initialize();
            List<string> lst = myCon.SelectRoomsToList();//roomNameCapacity
            this.listRooms.HeaderText = "Аудитории";

            foreach (string room in lst)
            {
                this.listRooms.Items.AddRange(new object[] { room });
            }

            this.listRooms.Width = 110;
            this.listRooms.Name = "roomsList";
            this.dataGridView1.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[] { this.listRooms });
        }
        void addSubGroupList()
        {
            this.listSubGroups = new System.Windows.Forms.DataGridViewComboBoxColumn();

            // 
            // list
            // 
            //myCon.Initialize();
            List<string> lst = new List<string>();
            lst.Add("все");
            lst.Add("1");
            lst.Add("2");
            this.listSubGroups.HeaderText = "Подгруппы";

            foreach (string subgr in lst)
            {
                this.listSubGroups.Items.AddRange(new object[] { subgr });
            }

            this.listSubGroups.Width = 80;
            this.listSubGroups.Name = "subGroupList";
            this.dataGridView1.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[] { this.listSubGroups });
        }

        void addSpecsList()
        {
            this.listSpecs = new System.Windows.Forms.DataGridViewComboBoxColumn();

            // 
            // list
            // 
            myCon.Initialize();
            List<string> lst = myCon.SelectSpecsToList();
            this.listSpecs.HeaderText = "Специализации";

            foreach (string spec in lst)
            {
                this.listSpecs.Items.AddRange(new object[] { spec });
            }

            this.listSpecs.Width = 200;
            this.listSpecs.Name = "specsList";
            this.dataGridView1.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[] { this.listSpecs });
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                InsertUpdate(dataGridView1, e.RowIndex);
            }));

        }
        /// <summary>
        /// nameDayOfWeek by numDayOfWeek, 
        /// klassnameyear2 by idKlass,
        /// prepodsList by idPrepod, 
        /// roomsList by idRoom,
        /// subGroupList by numSubgroup
        /// specsList by idSpec
        /// </summary>
        void SetDayName_SubGrup_AllRows()
        {
            //return;

            foreach (DataGridViewRow currow in dataGridView1.Rows)
            {
                int curRowNum = currow.Index;
                if (curRowNum >= 15)
                {
                    var stop = "here";
                }
                int dayId = 0;
                object DayVal = currow.Cells["numDayOfWeek"].Value;
                if (DayVal != DBNull.Value && DayVal != null)
                {
                    dayId = int.Parse(DayVal.ToString());
                    string dayname = DayName(dayId);
                    currow.Cells["nameDayOfWeek"].Value = dayname;
                }
                //object valSub = currow.Cells["subGroupList"].Value;
                DataGridViewComboBoxCell subCell = (DataGridViewComboBoxCell)currow.Cells["subGroupList"];
                currow.Cells["subGroupList"].Value = subCell.Items[0];
                //if (name == "id" || name == "idKlass" || name == "idPrepod" || name == "idRoom" || name == "isSubGroup")
                //KLASS NAME YEAR
                object klassIdV = currow.Cells["idKlass"].Value;
                if (klassIdV != DBNull.Value && klassIdV != null)
                {

                    //get name by id


                    string curKlasId = klassIdV.ToString();
                    bool isEmptuy = string.IsNullOrEmpty(curKlasId);
                    if (curKlasId != "")
                    {
                        DataGridViewComboBoxCell subCellKlass = (DataGridViewComboBoxCell)currow.Cells["Klass_Year_222"];
                        myCon.Initialize();
                        string curKlasName = "";
                        List<ListKlasses> lst = myCon.SelectKlassesToList();
                        foreach (var klass in lst)
                        {
                            if (klass.ID == curKlasId)
                            {
                                curKlasName = klass.ToString();
                            }
                        }
                        int counter = 0;
                        foreach (var item in subCellKlass.Items)
                        {
                            if (item.ToString() == curKlasName)
                            {
                                currow.Cells["Klass_Year_222"].Value = subCellKlass.Items[counter];
                                break;
                            }
                            counter++;
                        }
                    }
                    //currow.Cells["Klass_Year_222"].Value = subCell.Items[0];


                }
                //PREPOD
                object prepIdV = currow.Cells["idPrepod"].Value;
                if (prepIdV != DBNull.Value && prepIdV != null)
                {

                    string curPrepId = prepIdV.ToString();
                    string curPrepName = "";
                    if (curPrepId != "")
                    {
                        DataGridViewComboBoxCell subCellprepodsList = (DataGridViewComboBoxCell)currow.Cells["prepodsList"];
                        //get name by id
                        myCon.Initialize();
                        curPrepName = myCon.SelectPrepodsNameById(curPrepId);

                        int counter = 0;
                        foreach (var item in subCellprepodsList.Items)
                        {
                            if (item.ToString() == curPrepName)
                            {
                                currow.Cells["prepodsList"].Value = subCellprepodsList.Items[counter];
                                break;
                            }
                            counter++;
                        }
                    }
                }
                //ROOM
                object idRoomV = currow.Cells["idRoom"].Value;
                if (idRoomV != DBNull.Value && idRoomV != null)
                {

                    string curRoomId = idRoomV.ToString();
                    string curRoomName = "";
                    if (curRoomId != "")
                    {
                        DataGridViewComboBoxCell roomsList = (DataGridViewComboBoxCell)currow.Cells["roomsList"];
                        //get name by id
                        myCon.Initialize();
                        curRoomName = myCon.SelectRoomNameById(curRoomId);

                        int counter = 0;
                        foreach (var item in roomsList.Items)
                        {
                            if (item.ToString() == curRoomName)
                            {
                                currow.Cells["roomsList"].Value = roomsList.Items[counter];
                                break;
                            }
                            counter++;
                        }
                    }



                }
                //SUBGRUPS
                object numSubGroupV = currow.Cells["numSubGroup"].Value;
                if (numSubGroupV != DBNull.Value && numSubGroupV != null)
                {
                    string nsg = numSubGroupV.ToString();
                    if (nsg != "")
                    {
                        DataGridViewComboBoxCell subGroupList = (DataGridViewComboBoxCell)currow.Cells["subGroupList"];

                        int curSubGrup = Convert.ToInt32(nsg);
                        currow.Cells["subGroupList"].Value = subGroupList.Items[curSubGrup];
                    }
                }
                //SPECS
                object idSpecsV = currow.Cells["idSpec"].Value;
                if (idSpecsV != DBNull.Value && idSpecsV != null)
                {

                    string curSpecId = idSpecsV.ToString();
                    string curSpecName = "";
                    if (curSpecId != "")
                    {
                        DataGridViewComboBoxCell specsList = (DataGridViewComboBoxCell)currow.Cells["specsList"];
                        //get name by id
                        myCon.Initialize();
                        curSpecName = myCon.SelectSpecNameById(curSpecId);

                        int counter = 0;
                        foreach (var item in specsList.Items)
                        {
                            if (item.ToString() == curSpecName)
                            {
                                currow.Cells["specsList"].Value = specsList.Items[counter];
                                break;
                            }
                            counter++;
                        }
                    }



                }


            }


        }
        void SetDayName_Only()
        {
            //return;            
            foreach (DataGridViewRow currow in dataGridView1.Rows)
            {

                int dayId = 0;
                object DayVal = currow.Cells["numDayOfWeek"].Value;
                if (DayVal != DBNull.Value && DayVal != null)
                {
                    string dv = DayVal.ToString();
                    if (dv != "")
                    {
                        dayId = int.Parse(DayVal.ToString());
                        string dayname = DayName(dayId);

                        currow.Cells["nameDayOfWeek"].Value = dayname;
                    }
                }
            }
        }




        private void InsertUpdate(DataGridView dataGridView1, int ind)
        {
            int currowind = ind;
            DataGridViewRow currow = dataGridView1.Rows[currowind];
            object klassnameyear2Val = currow.Cells["Klass_Year_222"].Value;
            int klassId = 0;
            if (klassnameyear2Val != DBNull.Value && klassnameyear2Val != null)
            {

                string klassnameyear = klassnameyear2Val.ToString();//10-1 (2015)
                string[] subs1 = klassnameyear.Split('(');
                string klassname = subs1[0].Trim();
                string klassyear = subs1[1].Replace("(", "").Replace(")", "").Trim();
                myCon.Initialize();
                klassId = myCon.GetKlassId(klassname, klassyear);
            }
            int roomId = 0;
            object RoomNameCapacityVal = currow.Cells["roomsList"].Value;
            if (RoomNameCapacityVal != DBNull.Value && RoomNameCapacityVal != null)
            {

                string RoomNameCapacity = RoomNameCapacityVal.ToString();//110 (10)
                string[] subs1 = RoomNameCapacity.Split('(');
                string roomName = subs1[0].Trim();
                string roomCapacity = subs1[1].Replace("(", "").Replace(")", "").Trim();
                myCon.Initialize();
                roomId = myCon.GetRoomId(roomName, roomCapacity);
            }
            int prepodId = 0;
            object PrepFioFullVal = currow.Cells["prepodsList"].Value;
            if (PrepFioFullVal != DBNull.Value && PrepFioFullVal != null)
            {

                string PrepFioFull = PrepFioFullVal.ToString();//
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
            int NumSubGrup = 0;
            object SubGrupVal = currow.Cells["subGroupList"].Value;
            if (SubGrupVal != DBNull.Value && SubGrupVal != null)
            {

                string SubGrup = SubGrupVal.ToString();//
                //prepodsList - fioBday
                if (string.Compare(SubGrup, "все", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    NumSubGrup = 0;
                }
                else if (string.Compare(SubGrup, "1", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    NumSubGrup = 1;
                }
                else if (string.Compare(SubGrup, "2", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    NumSubGrup = 2;
                }
            }
            SetDayName_Only();
            //ListKlassesClass lk = (ListKlassesClass)idValue;
            //************specs
            int specId = 0;
            object specsListVal = currow.Cells["specsList"].Value;
            if (specsListVal != DBNull.Value && specsListVal != null)
            {

                string spec = specsListVal.ToString();//
                //prepodsList - fioBday
                if (spec.Contains("("))
                {
                    string specCourse = "";
                    string specSem = "";
                    string[] subs1 = spec.Split('(');
                    string specNameFull = subs1[0].Trim();
                    specCourse = subs1[1].Replace("(", "").Replace(")", "").Trim();
                    if (subs1.Length > 2)
                    {
                        specSem = subs1[2].Replace("(", "").Replace(")", "").Trim();
                    }
                    myCon.Initialize();
                    specId = myCon.GetSpecId(specNameFull, specCourse, specSem);
                }
                else
                {
                    myCon.Initialize();
                    specId = myCon.GetSpecId(spec);
                }
            }
            //
            //добавление
            int indRow = ind;
            int countRows = dataGridView1.Rows.Count;

            //DataGridViewRow currow = dataGridView1.Rows[indRow];

            object idValue = currow.Cells["id"].Value;
            if (klassId != 0 && prepodId != 0 && roomId != 0 && specId != 0)
            {
                if (idValue == DBNull.Value || idValue == null)
                {
                    //insert new
                    //numday, iseven, ispair 
                    object numDayOfWeek = currow.Cells["numDayOfWeek"].Value;
                    if (numDayOfWeek != null && numDayOfWeek != DBNull.Value && string.IsNullOrEmpty(numDayOfWeek.ToString()) == false)
                    {
                        int iNumDayOfWeek = int.Parse(numDayOfWeek.ToString());
                        bool isPair = false;
                        if (currow.Cells["isPair"].Value == DBNull.Value || currow.Cells["isPair"].Value == null)
                        {
                            isPair = false;
                        }
                        else
                        {
                            isPair = (bool)currow.Cells["isPair"].Value;
                        }
                        bool isEven = false;
                        if (currow.Cells["isEven"].Value == DBNull.Value || currow.Cells["isEven"].Value == null)
                        {
                            isEven = false;
                        }
                        else
                        {
                            isEven = (bool)currow.Cells["isPair"].Value;
                        }

                        object lessonNumberV = currow.Cells["lessonNumber"].Value;
                        string nameDay = currow.Cells["nameDayOfWeek"].Value.ToString();
                        bool check = (iNumDayOfWeek >= 1 && iNumDayOfWeek <= 7 && lessonNumberV != null && lessonNumberV != DBNull.Value);
                        //TODO: add spec list + id
                        //int specId = 0;
                        if (check)
                        {
                            int lessonNum = int.Parse(lessonNumberV.ToString());
                            bool isSubGrup = (NumSubGrup != 0);
                            myCon.Initialize();
                            //DateTime dt = DateTime.Parse(BDay.ToString());
                            //get id from shedule table

                            int insertedId = myCon.InsertSchedule(lessonNum, specId, klassId, isSubGrup, numDayOfWeek, nameDay, prepodId, roomId, NumSubGrup, isEven, isPair);
                            //set it in row
                            currow.Cells["id"].Value = insertedId;
                            //selectTOGrid();
                            //UpdateIdSchedule(lessonNum, specId, klassId, isSubGrup, numDayOfWeek, nameDay, prepodId, roomId, NumSubGrup, isEven, isPair);
                        }
                    }
                }
                else
                {
                    //update existing
                    object id = currow.Cells["id"].Value;
                    bool isSubGrup = (NumSubGrup != 0);
                    object numDayOfWeek = currow.Cells["numDayOfWeek"].Value;
                    if (numDayOfWeek != null && numDayOfWeek != DBNull.Value && string.IsNullOrEmpty(numDayOfWeek.ToString()) == false)
                    {

                        int iNumDayOfWeek = int.Parse(numDayOfWeek.ToString());
                        object objIsPair = currow.Cells["isPair"].Value;
                        object objisEven = currow.Cells["isEven"].Value;
                        bool isPair = false;
                        if (objIsPair != null && objIsPair != DBNull.Value)
                        {
                            isPair = Convert.ToBoolean(objIsPair);
                        }
                        bool isEven = false;
                        if (objisEven != null && objisEven != DBNull.Value)
                        {
                            isEven = Convert.ToBoolean(objisEven);
                        }


                        object lessonNumberV = currow.Cells["lessonNumber"].Value;
                        string nameDay = currow.Cells["nameDayOfWeek"].Value.ToString();
                        bool check = (iNumDayOfWeek >= 1 && iNumDayOfWeek <= 7 && lessonNumberV != null && lessonNumberV != DBNull.Value);
                        //TODO: add spec list + id
                        //int specId = 0;
                        if (check)
                        {
                            int lessonNum = int.Parse(lessonNumberV.ToString());

                            myCon.Initialize();
                            myCon.Updatechedule(id.ToString(), lessonNum, specId, klassId, isSubGrup, numDayOfWeek, nameDay, prepodId, roomId, NumSubGrup, isEven, isPair);

                            //myCon.UpdateRoom(capacity.ToString(), roomname.ToString(), "", id.ToString());

                            //selectTOGrid();
                        }
                    }
                }
            }

        }
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            //char key = e.;
            if (e.KeyData == Keys.Delete)
            {
                //delete
                int indRow = dataGridView1.CurrentRow.Index;
                var currow = dataGridView1.Rows[indRow];
                object idValue = currow.Cells["id"].Value;
                if (idValue != null && idValue != DBNull.Value)
                {
                    myCon.Initialize();
                    myCon.DeleteShedule(idValue.ToString());
                }
                selectTOGrid();
                //MessageBox.Show("delete UP row="+indRow);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ScheduleCrud_Load(object sender, EventArgs e)
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
        }
    }
}
