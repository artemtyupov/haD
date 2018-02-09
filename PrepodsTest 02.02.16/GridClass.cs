/*
 * Created by SharpDevelop.
 * User: kornout
 * Date: 20.11.2015
 * Time: 17:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Remoting.Messaging;

namespace PrepodsTest
{
    public class ListKlasses
    {
        public string ID;
        public string name;
        public string people;
        public string yearofstudy;
        public ListKlasses(string iid, string iname, string ipeople, string iyearofstudy)
		{
			ID=iid;
            name = iname;
            people = ipeople;
            yearofstudy = iyearofstudy;
		}
        public override string ToString()
        {
            return name.ToString()+" ("+yearofstudy+")";
        }
    }
	/// <summary>
	/// prepods for grid
	/// </summary>
	public class GridPrepods
	{
		public string ID;
		public string FioFull;
		public string FioShort;
		public string MobPhone;
		public string Birthday;
		//public string Bday { get return this.bi 
		public GridPrepods()
		{
			//ID="";
		}
		public GridPrepods(string iid,string iFioFull,string iFioShort,string imobphone,DateTime ibirth)
		{
			ID=iid;
			FioFull =iFioFull;
			FioShort =iFioShort;
			MobPhone = imobphone;
			Birthday= convertBDay2(ibirth);
		}
		public string convertBDay(string bday)
		{
			//yyyy-MM-dd
			DateTime bdaydt = DateTime.Parse(bday);
			//dd.MM.yyyy
			return bdaydt.ToString("dd.MM.yyyy");
		}
		public string convertBDay2(DateTime bday)
		{
			//yyyy-MM-dd
			//DateTime bdaydt = DateTime.Parse(bday);
			//dd.MM.yyyy
			return bday.ToString("dd.MM.yyyy");
		}
	}
    /// <summary>
    /// prepods for grid
    /// </summary>
    public class GridPrepodsReplace
    {
        public string ID;
        public string FioFull;
        public string FioShort;
        public string MobPhone;
        public string Birthday;
        //public string Bday { get return this.bi 
        public GridPrepodsReplace()
        {
            //ID="";
        }
        public GridPrepodsReplace(string iid, string iFioFull, string iFioShort, string imobphone, DateTime ibirth)
        {
            ID = iid;
            FioFull = iFioFull;
            FioShort = iFioShort;
            MobPhone = imobphone;
            Birthday = convertBDay2(ibirth);
        }
        public string convertBDay(string bday)
        {
            //yyyy-MM-dd
            DateTime bdaydt = DateTime.Parse(bday);
            //dd.MM.yyyy
            return bdaydt.ToString("dd.MM.yyyy");
        }
        public string convertBDay2(DateTime bday)
        {
            //yyyy-MM-dd
            //DateTime bdaydt = DateTime.Parse(bday);
            //dd.MM.yyyy
            return bday.ToString("dd.MM.yyyy");
        }
    }
	/// <summary>
	/// Specs for checkbox
	/// </summary>
	public class GridSpecs
	{
		public string ID;
		public string name;
		public string course;
		public string semester;
		public string Комментарий;
		//public string Bday { get return this.bi 
		public GridSpecs()
		{
			//ID="";
		}
		public GridSpecs(string iid,string iname,string icourse,string isemester,string iКомментарий)
		{
			ID=iid;
			name =iname;
			course = icourse;
			semester =isemester;
			Комментарий = iКомментарий;
			//Birthday= convertBDay2(ibirth);
		}
		
	}
    /// <summary>
    /// klasses for checkbox
    /// </summary>
    public class GridKlasses
    {
        public string ID;
        public string name;
        public string people;
        public string yearofstudy;
        
        //public string Bday { get return this.bi 
        public GridKlasses()
        {
            //ID="";
        }
        public GridKlasses(string iid, string iname, string ipeople, string iyearofstudy)
        {
            ID = iid;
            name = iname;
            people = ipeople;
            yearofstudy = iyearofstudy;
            
            //Birthday= convertBDay2(ibirth);
        }

    }
}
