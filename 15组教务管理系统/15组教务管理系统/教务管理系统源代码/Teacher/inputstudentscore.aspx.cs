using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class inputstudentscore : System.Web.UI.Page
{
    CommDB mydb = new CommDB();
    DataSet myds = new DataSet();
    string mysql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            mysql = "SELECT cno FROM course WHERE tno='" + Session["uno"] + "'";
            myds = mydb.ExecuteQuery(mysql, "course");
            if (myds.Tables["course"].Rows.Count > 0)
            {
                DropDownList1.DataSource = myds.Tables["course"];
                DropDownList1.DataTextField = "cno";
                DropDownList1.DataBind();
            }
            else
                Response.Redirect("~/dispinfo.aspx?info=没有安排任何上课课程!");
            Button2.Visible = false;
            Button3.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mysql;
        mysql = "SELECT * FROM score WHERE tno='" + Session["uno"] + "'AND cno ='" + DropDownList1.SelectedValue + "' ORDER BY sno";
        myds = mydb.ExecuteQuery(mysql, "score");
        if (myds.Tables["score"].Rows.Count > 0)
        {
            GridView1.DataSource = myds.Tables["score"];
            GridView1.DataBind();
            Button2.Visible = true;
            Button3.Visible = true;
        }
        else
            Response.Write("<script>alert('没有学生选修或提交该课程!')</script>");

    }
    protected void Button2_Click(object sender, EventArgs e)
    {   
        savedata();
        Response.Redirect("~/dispinfo.aspx?info=输入的成绩已保存!");
    }
    protected void savedata() 
    {
        string no;
        TextBox txtbh;
        int i;
        for (i = 0; i < GridView1.Rows.Count; i++)
        {
            txtbh = GridView1.Rows[i].FindControl("TextBox1") as TextBox;
           
            no = GridView1.Rows[i].Cells[0].Text;	
            Update(no, txtbh.Text);				    
        }
    }
    protected void Update(string no, string fs)
    {
        mysql = "UPDATE score SET degree=" + fs + " WHERE sno = '" +
            no + "' AND cno='" + DropDownList1.SelectedValue + "'";
        mydb.ExecuteNonQuery(mysql);
    }   
}
