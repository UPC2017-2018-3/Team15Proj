﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    CommDB mydb = new CommDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)            
            Label1.Text = mydb.RandomNum(4);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mysql;
        int i;
        string uname = "";
        if (TextBox3.Text.Trim() != Label1.Text.Trim()) 
            Response.Write("<script>alert('你的验证码输入错误，请重输入!')</script>");
        else
        {
            if (RadioButton1.Checked)   
            {
                mysql = "SELECT sname FROM student WHERE sno = '" + TextBox1.Text + "' AND spass = '" + TextBox2.Text + "'";
                i = mydb.Rownum(mysql, "student", ref uname);
                if (i > 0)              
                {
                    Session["uno"] = TextBox1.Text.Trim();      
                    Session["uname"] = uname;	                
                    Server.Transfer("~/studentmenu.aspx");
                }
                else    
                    Response.Write("<script>alert('对不起，你输入的用户名或者密码错误，请查实!')</script>");
            }
            else if (RadioButton2.Checked)   
            {
                mysql = "SELECT tname FROM teacher WHERE tno = '" + TextBox1.Text + "' AND tpass = '" + TextBox2.Text + "'";
                i = mydb.Rownum(mysql, "teacher", ref uname);
                if (i > 0)             
                {
                    Session["uno"] = TextBox1.Text.Trim();     
                    Session["uname"] = uname;	                
                    Server.Transfer("~/teachermenu.aspx");
                }
                else   
                    Response.Write("<script>alert('对不起，你输入的用户名或者密码错误，请查实!')</script>");
            }
            else if (RadioButton3.Checked)   
            {
                mysql = "SELECT mname FROM manager WHERE mno = '" + TextBox1.Text + "' AND mpass = '" + TextBox2.Text + "'";
                i = mydb.Rownum(mysql, "manager", ref uname);
                if (i > 0)              
                {
                    Session["uno"] = TextBox1.Text.Trim();      
                    Session["uname"] = uname;	                
                    Server.Transfer("~/managermenu.aspx");
                }
                else   
                    Response.Write("<script>alert('对不起，你输入的用户名或者密码错误，请查实!')</script>");
            }
            else   
                Response.Write("<script>alert('对不起，必须选择用户类型!')</script>");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Label1.Text = mydb.RandomNum(4);
    }
}
