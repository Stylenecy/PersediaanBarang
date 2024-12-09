using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

public class Tabel
{
	private String namaTabel;
	private DataTable dt;
	private BindingSource bs;

	public Tabel(String namaTabel)
	{
		this.namaTabel = namaTabel;
		this.dt = new DataTable();
		this.bs = new BindingSource();
		string conStr = "server=localhost;user id=root;password='';database=inv";
		this.conn = new MySqlConnection(conStr);
	}

	void isiDataTable()
	{
		try
		{
			conn.Open();
			MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + this.namaTabel, conn);
			MySqlDataAdapter da = new MySqlDataAdapter(cmd);
			dt.Clear();
			da.Fill(this.dt);
			bs.DataSource = dt;
		}
		catch 
		{
			MessageBox.Show(ex.Message);
		}
		finally
		{
			conn.Close();
		}

		void eksekusiSQL(String stringSQL)
		{
			conn.Open();
			MySqlCommand cmd = new MySqlCommand(stringSQL, conn);
			cmd.ExecutionQuery();
		}


	}
}
