using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public class CommDB
{
	public CommDB()   
	{}
    public int Rownum(string sql,string tname,ref string sname)
    {
        int i=0;
        string mystr = ConfigurationManager.AppSettings["myconnstring"];
        SqlConnection myconn = new SqlConnection
        {
            ConnectionString = mystr
        };
        myconn.Open();
        SqlCommand mycmd = new SqlCommand(sql, myconn);
        SqlDataReader myreader = mycmd.ExecuteReader();
        while (myreader.Read())　　
        {
            sname = myreader[0].ToString();
            i++;
        }
        myconn.Close();
        return i; 
    }
    public Boolean ExecuteNonQuery(string sql)
    {
        string mystr = ConfigurationManager.AppSettings["myconnstring"];
        SqlConnection myconn = new SqlConnection
        {
            ConnectionString = mystr
        };
        myconn.Open();
        SqlCommand mycmd = new SqlCommand(sql,myconn);
        try
        {
            mycmd.ExecuteNonQuery();
            myconn.Close();
        }
        catch
        {
            myconn.Close();
            return false;
        }
        return true;
    }
    public DataSet ExecuteQuery(string sql,string tname)
    {
        string mystr = ConfigurationManager.AppSettings["myconnstring"];
        SqlConnection sqlConnection = new SqlConnection
        {
            ConnectionString = mystr
        };
        SqlConnection myconn = sqlConnection;
        myconn.Open();
        SqlDataAdapter myda = new SqlDataAdapter(sql,myconn);
        DataSet myds = new DataSet();
        myda.Fill(myds,tname);
        myconn.Close();
        return myds;
    }
    public string RandomNum(int n)     
    {
        string strchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H," + 
            "I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z," +
            "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        string[] arry = strchar.Split(',');
        string num = "";       
        int temp = -1;
        Random rand = new Random();
        for (int i = 1;i<n + 1;i++)
        {
            if (temp != -1)
            {
                rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
            }
            int t = rand.Next(61);
            if (temp != -1 && temp == t)
            {
                return RandomNum(n);
            }
            temp = t;
            num += arry[t];
        }
        return num;       
    }
}
