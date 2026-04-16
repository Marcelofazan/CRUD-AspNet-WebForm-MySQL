using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = System.Web.UI.WebControls.Image;

namespace Simples
{
    public partial class _Default : Page
    {
        #region MySqlConnection Connection and Page Lode
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["TesteConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["EMPRESA"] != null)
            //{
            //    Label10.Text = Session["EMPRESA"].ToString();
            //}
            //else
            //{
            //    Response.Redirect("default.aspx");
            //}

            Label10.Text = "1"; // Empresa 1 Ativada 

            string varEMPRESA = Label10.Text;
            DataTable dt = new DataTable();
            GrdListaPessoaQualificacao.DataSource = GetData("SELECT t.DESCRICAO AS 'QUALIFICACAO', a.NOME AS 'NOME' FROM PESSOAS a JOIN QUALIFICACAO t ON a.QUALIFICACAO=t.CODIGO WHERE  a.EMPRESA='" + varEMPRESA + "' GROUP BY t.DESCRICAO , a.NOME");
            GrdListaPessoaQualificacao.DataBind();

            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 1;
                tabMenu.Items[MultiView1.ActiveViewIndex].Selected = true;

                try
                {
                    if (!Page.IsPostBack)
                    {
                        BindGridView();
                    }
                }
                catch (MySqlException ex)
                {
                    ShowMessage(ex.Message);
                }
            }
        }

        #endregion

        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            conn.Open();

            using (MySqlDataAdapter sda = new MySqlDataAdapter())
            {
                string varEMPRESA = Label10.Text;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            conn.Close();
            return dt;
        }
        protected void OnDataBound(object sender, EventArgs e)
        {
            for (int i = GrdListaPessoaQualificacao.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = GrdListaPessoaQualificacao.Rows[i];
                GridViewRow previousRow = GrdListaPessoaQualificacao.Rows[i - 1];
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    if (row.Cells[j].Text == previousRow.Cells[j].Text)
                    {
                        if (previousRow.Cells[j].RowSpan == 0)
                        {
                            if (row.Cells[j].RowSpan == 0)
                            {
                                previousRow.Cells[j].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                            }
                            row.Cells[j].Visible = false;
                        }
                    }
                }
            }
        }
        protected void tabMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "t1":
                    MultiView1.ActiveViewIndex = 0;
                    break;
                case "t2":
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "t3":
                    MultiView1.ActiveViewIndex = 2;
                    break;
                case "t4":
                    MultiView1.ActiveViewIndex = 3;
                    break;
            }
        }
        #region show message
        /// <summary>
        /// This function is used for show message.
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(string msg)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('" + msg + "');</script>");
        }
        /// <summary>
        /// This Function is used TextBox Empty.
        /// </summary>
        void clear()
        {
            txtQUALIFICACAO.Text = string.Empty;
            txtNOME.Text = string.Empty;
            txtEMAIL.Text = string.Empty;
            txtCNPJ.Text = string.Empty;
            txtENDERECO.Text = string.Empty;
            txtNUMERO.Text = string.Empty;
            txtCOMPLEMENTO.Text = string.Empty;
            txtBAIRRO.Text = string.Empty;
            txtCIDADE.Text = string.Empty;
            txtCEP.Text = string.Empty;
            txtPAIS.Text = string.Empty;
            txtTELEFONE.Text = string.Empty;
            txtCELULAR.Text = string.Empty;
            Label3.Text = string.Empty;
            Image1.ImageUrl = null;
            txtQUALIFICACAO.Focus();
        }

        #endregion
        #region bind data to Grid
        private void BindGridView()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string varEMPRESA = Label10.Text;
                MySqlCommand cmd = new MySqlCommand("Select * from PESSOAS WHERE EMPRESA='" + varEMPRESA + "' ORDER BY QUALIFICACAO , NOME DESC;", conn);
                cmd.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                GrdPessoas.DataSource = ds;
                GrdPessoas.DataBind();
                lbltotalcount.Text = GrdPessoas.Rows.Count.ToString();
                if (GrdPessoas.Rows.Count > 0)
                    GrdPessoas.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            catch (MySqlException ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string varEMPRESA = Label10.Text;
                MySqlCommand cmd = new MySqlCommand("Select * from QUALIFICACAO WHERE EMPRESA='" + varEMPRESA + "' ORDER BY DESCRICAO DESC;", conn);
                cmd.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                GrdQualificacao.DataSource = ds;
                GrdQualificacao.DataBind();
                lbltotalcount2.Text = GrdQualificacao.Rows.Count.ToString();
                if (GrdQualificacao.Rows.Count > 0)
                    GrdQualificacao.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (MySqlException ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region SelectedIndexChanged
        /// <summary>
        /// this code used to GridViewRow SelectedIndexChanged value show textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdPessoas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GrdPessoas.SelectedRow;
            lblSID.Text = GrdPessoas.DataKeys[row.RowIndex]["CODIGO"].ToString();
            Label10.Text = GrdPessoas.DataKeys[row.RowIndex]["EMPRESA"].ToString();
            txtQUALIFICACAO.Text = GrdPessoas.DataKeys[row.RowIndex]["QUALIFICACAO"].ToString();

            conn.Open();
            string SID = GrdPessoas.DataKeys[row.RowIndex]["CODIGO"].ToString();
            string SID2 = GrdPessoas.DataKeys[row.RowIndex]["QUALIFICACAO"].ToString();
            string varEMPRESA = Label10.Text;
            MySqlCommand cmd = new MySqlCommand("Select B.DESCRICAO FROM PESSOAS A INNER JOIN QUALIFICACAO B ON (A.QUALIFICACAO = B.CODIGO) WHERE B.CODIGO ='" + SID2 + "' AND  A.EMPRESA ='" + varEMPRESA + "' AND  B.EMPRESA ='" + varEMPRESA + "' ", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label3.Text = dr["DESCRICAO"].ToString();
                }
            }
            conn.Close();
            txtNOME.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
            txtEMAIL.Text = HttpUtility.HtmlDecode(row.Cells[6].Text);
            txtCNPJ.Text = HttpUtility.HtmlDecode(row.Cells[7].Text);
            txtENDERECO.Text = GrdPessoas.DataKeys[row.RowIndex]["ENDERECO"].ToString();
            txtNUMERO.Text = GrdPessoas.DataKeys[row.RowIndex]["NUMERO"].ToString();
            txtCOMPLEMENTO.Text = GrdPessoas.DataKeys[row.RowIndex]["COMPLEMENTO"].ToString();
            txtBAIRRO.Text = GrdPessoas.DataKeys[row.RowIndex]["BAIRRO"].ToString();
            txtCIDADE.Text = GrdPessoas.DataKeys[row.RowIndex]["CIDADE"].ToString();
            txtCEP.Text = GrdPessoas.DataKeys[row.RowIndex]["CEP"].ToString();
            txtPAIS.Text = GrdPessoas.DataKeys[row.RowIndex]["PAIS"].ToString();
            txtTELEFONE.Text = GrdPessoas.DataKeys[row.RowIndex]["TELEFONE"].ToString();
            txtCELULAR.Text = GrdPessoas.DataKeys[row.RowIndex]["CELULAR"].ToString();

            using (MySqlCommand cmd2 = new MySqlCommand("Select FOTO FROM PESSOAS WHERE CODIGO ='" + lblSID.Text + "' AND EMPRESA ='" + varEMPRESA + "' ", conn))
            {
                cmd2.Parameters.AddWithValue("@CODIGO", SID);
                cmd2.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
                conn.Open();

                // Lê os dados binários
                object result = cmd2.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    byte[] bytes = (byte[])result;

                    // Converte byte array para base64 string
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

                    // Exibe no Image control (ajuste o mime type image/png ou image/jpeg)
                    Image1.ImageUrl = "data:image/png;base64," + base64String;
                }
                conn.Close();
            }

            Response.Write(row.Cells[4].Text);
            MultiView1.ActiveViewIndex = 0;
            tabMenu.Items[MultiView1.ActiveViewIndex].Selected = true;
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
        }
        #endregion
        #region Insert Data
        /// <summary>
        /// this code used to Student Data insert in MYSQL Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if ((txtQUALIFICACAO.Text.Trim() == "") && (string.IsNullOrWhiteSpace(txtQUALIFICACAO.Text.Trim())))
            {
                ShowMessage("Necessário Selecionar uma Qualificação");
                clear();
                MultiView1.ActiveViewIndex = 1;
                tabMenu.Items[MultiView1.ActiveViewIndex].Selected = true;
                return;
            }

            if ((txtNOME.Text.Trim() == "") && (string.IsNullOrWhiteSpace(txtNOME.Text.Trim())))
            {
                ShowMessage("Necessário Informar uma Pessoa");
                clear();
                MultiView1.ActiveViewIndex = 1;
                tabMenu.Items[MultiView1.ActiveViewIndex].Selected = true;
                return;
            }

            try
            {
                conn.Open();
                string varEMPRESA = Label10.Text;
                MySqlCommand cmd = new MySqlCommand("Insert into PESSOAS (EMPRESA, QUALIFICACAO, NOME, EMAIL, CNPJ, ENDERECO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, CEP, PAIS, TELEFONE , CELULAR ) values ( '" + varEMPRESA + "' , @QUALIFICACAO, @NOME, @EMAIL, @CNPJ, @ENDERECO, @NUMERO, @COMPLEMENTO, @BAIRRO, @CIDADE, @CEP, @PAIS, @TELEFONE , @CELULAR)", conn);
                cmd.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
                cmd.Parameters.AddWithValue("@QUALIFICACAO", txtQUALIFICACAO.Text.Trim());
                cmd.Parameters.AddWithValue("@NOME", txtNOME.Text.Trim());
                cmd.Parameters.AddWithValue("@EMAIL", txtEMAIL.Text.Trim());
                cmd.Parameters.AddWithValue("@CNPJ", txtCNPJ.Text.Trim());
                cmd.Parameters.AddWithValue("@ENDERECO", txtENDERECO.Text.Trim());
                cmd.Parameters.AddWithValue("@NUMERO", txtNUMERO.Text.Trim());
                cmd.Parameters.AddWithValue("@COMPLEMENTO", txtCOMPLEMENTO.Text.Trim());
                cmd.Parameters.AddWithValue("@BAIRRO", txtBAIRRO.Text.Trim());
                cmd.Parameters.AddWithValue("@CIDADE", txtCIDADE.Text.Trim());
                cmd.Parameters.AddWithValue("@CEP", txtCEP.Text.Trim());
                cmd.Parameters.AddWithValue("@PAIS", txtPAIS.Text.Trim());
                cmd.Parameters.AddWithValue("@TELEFONE", txtTELEFONE.Text.Trim());
                cmd.Parameters.AddWithValue("@CELULAR", txtCELULAR.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                ShowMessage("Registro Gravado com Sucesso......!");
                clear();
                BindGridView();
            }
            catch (MySqlException ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
        #region Delete Data
        /// <summary>
        /// This code used to GrdListaPessoaQualificacao_RowDeleting Student Data Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdPessoas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                conn.Open();
                string varEMPRESA = Label10.Text;
                int SID = Convert.ToInt32(GrdPessoas.DataKeys[e.RowIndex].Value);
                MySqlCommand cmd = new MySqlCommand("Delete From PESSOAS where CODIGO='" + SID + "' and EMPRESA='" + varEMPRESA + "'", conn);
                cmd.Parameters.AddWithValue("@CODIGO", SID);
                cmd.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                ShowMessage("Registro Excluido com Sucesso......!");
                clear();
                GrdPessoas.EditIndex = -1;
                BindGridView();
            }
            catch (MySqlException ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                conn.Close();
                btnSubmit.Visible = true;
                btnUpdate.Visible = false;
            }
        }
        #endregion
        #region Update Data 
        /// <summary>
        /// This code used to student data update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if ((txtQUALIFICACAO.Text.Trim() == "") && (string.IsNullOrWhiteSpace(txtQUALIFICACAO.Text.Trim())))
            {
                ShowMessage("Necessário Selecionar uma Qualificação");
                clear();
                MultiView1.ActiveViewIndex = 1;
                tabMenu.Items[MultiView1.ActiveViewIndex].Selected = true;
                return;
            }

            if ((txtNOME.Text.Trim() == "") && (string.IsNullOrWhiteSpace(txtNOME.Text.Trim())))
            {
                ShowMessage("Necessário Informar uma Pessoa");
                clear();
                MultiView1.ActiveViewIndex = 1;
                tabMenu.Items[MultiView1.ActiveViewIndex].Selected = true;
                return;
            }

            try
            {
                conn.Open();
                string SID = lblSID.Text;
                string varEMPRESA = Label10.Text;
                MySqlCommand cmd = new MySqlCommand("update PESSOAS Set QUALIFICACAO=@QUALIFICACAO, NOME=@NOME, EMAIL=@EMAIL, CNPJ=@CNPJ, ENDERECO=@ENDERECO, NUMERO=@NUMERO, COMPLEMENTO=@COMPLEMENTO, BAIRRO=@BAIRRO, CIDADE=@CIDADE, CEP=@CEP, PAIS=@PAIS , TELEFONE=@TELEFONE , CELULAR=@CELULAR where CODIGO='" + SID + "'  AND EMPRESA='" + varEMPRESA + "' ", conn);
                cmd.Parameters.AddWithValue("@QUALIFICACAO", txtQUALIFICACAO.Text.Trim());
                cmd.Parameters.AddWithValue("@NOME", txtNOME.Text.Trim());
                cmd.Parameters.AddWithValue("@EMAIL", txtEMAIL.Text.Trim());
                cmd.Parameters.AddWithValue("@CNPJ", txtCNPJ.Text.Trim());
                cmd.Parameters.AddWithValue("@ENDERECO", txtENDERECO.Text.Trim());
                cmd.Parameters.AddWithValue("@NUMERO", txtNUMERO.Text.Trim());
                cmd.Parameters.AddWithValue("@COMPLEMENTO", txtCOMPLEMENTO.Text.Trim());
                cmd.Parameters.AddWithValue("@BAIRRO", txtBAIRRO.Text.Trim());
                cmd.Parameters.AddWithValue("@CIDADE", txtCIDADE.Text.Trim());
                cmd.Parameters.AddWithValue("@CEP", txtCEP.Text.Trim());
                cmd.Parameters.AddWithValue("@PAIS", txtPAIS.Text.Trim());
                cmd.Parameters.AddWithValue("@TELEFONE", txtTELEFONE.Text.Trim());
                cmd.Parameters.AddWithValue("@CELULAR", txtCELULAR.Text.Trim());
                cmd.Parameters.AddWithValue("@CODIGO", SID);
                cmd.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                ShowMessage("Registro Alterado com Sucesso......!");
                clear();
                GrdPessoas.EditIndex = -1;
                BindGridView();
                btnUpdate.Visible = false;
            }
            catch (MySqlException ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                conn.Close();
                btnSubmit.Visible = true;
                btnUpdate.Visible = false;
            }
        }
        #endregion
        #region textbox clear
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            lblSID.Text = " cade ";
            clear();
        }
        #endregion

        #region SelectedIndexChanged
        /// <summary>
        /// this code used to GridViewRow SelectedIndexChanged value show textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GrdQualificacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GrdQualificacao.SelectedRow;
            txtQUALIFICACAO.Text = GrdQualificacao.DataKeys[row.RowIndex]["CODIGO"].ToString();
            Label3.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
            MultiView1.ActiveViewIndex = 0;
            tabMenu.Items[MultiView1.ActiveViewIndex].Selected = true;
        }
        #endregion

        protected void GrdPessoas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string varEMPRESA = Label10.Text;
            MySqlCommand cmd = new MySqlCommand("Select * from PESSOAS WHERE EMPRESA='" + varEMPRESA + "' ORDER BY QUALIFICACAO , NOME DESC;", conn);
            cmd.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            GrdPessoas.DataSource = ds;
            GrdPessoas.PageIndex = e.NewPageIndex;
            BindGridView();
        }
        protected void GrdQualificacao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string varEMPRESA = Label10.Text;
            MySqlCommand cmd = new MySqlCommand("Select * from QUALIFICACAO WHERE EMPRESA='" + varEMPRESA + "' ORDER BY DESCRICAO DESC;", conn);
            cmd.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            GrdQualificacao.DataSource = ds;
            GrdQualificacao.PageIndex = e.NewPageIndex;
            BindGridView();
        }
        protected void btnPesquisa1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            tabMenu.Items[MultiView1.ActiveViewIndex].Selected = true;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string SID = lblSID.Text;
            string varEMPRESA = Label10.Text;

            if ((lblSID.Text == " cade ") && (!string.IsNullOrWhiteSpace(Label10.Text)))
            {
                ShowMessage("Necessário Selecionar um Registro");
                clear();
                MultiView1.ActiveViewIndex = 1;
                tabMenu.Items[MultiView1.ActiveViewIndex].Selected = true;
                return;
            }

            string filename = Path.GetFileName(FileUploadControl.PostedFile.FileName);
            string contentType = FileUploadControl.PostedFile.ContentType;
            using (Stream fs = FileUploadControl.PostedFile.InputStream)
            {
                using (MySqlCommand cmd2 = new MySqlCommand("Select FOTO FROM PESSOAS WHERE CODIGO ='" + lblSID.Text + "' AND EMPRESA ='" + varEMPRESA + "' ", conn))
                {
                    cmd2.Parameters.AddWithValue("@CODIGO", SID);
                    cmd2.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
                    conn.Open();

                    // Lê os dados binários
                    object result = cmd2.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        byte[] bytes = (byte[])result;

                        // Converte byte array para base64 string
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

                        // Exibe no Image control (ajuste o mime type image/png ou image/jpeg)
                        Image1.ImageUrl = "data:image/png;base64," + base64String;
                    }

                    conn.Close();
                }

                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string constr = ConfigurationManager.ConnectionStrings["TesteConnectionString"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        string query2 = "UPDATE PESSOAS SET NOMEFOTO=@NOMEFOTO, CAMINHO=@CAMINHO, FOTO=@FOTO where CODIGO='" + lblSID.Text.Trim() + "'  AND EMPRESA='" + varEMPRESA + "'";
                        using (MySqlCommand cmd2 = new MySqlCommand(query2))
                        {
                            cmd2.Connection = con;
                            cmd2.Parameters.AddWithValue("@NOMEFOTO", filename);
                            cmd2.Parameters.AddWithValue("@CAMINHO", contentType);
                            cmd2.Parameters.AddWithValue("@FOTO", bytes);
                            cmd2.Parameters.AddWithValue("@CODIGO", lblSID.Text.Trim());
                            cmd2.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
                            con.Open();
                            cmd2.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
            FileUploadControl.SaveAs(filename);
            Image1.ImageUrl = "~/ImageHttpHandler.ashx?CODIGO=" + lblSID.Text + "&EMPRESA=" + Label10.Text;
        }

        protected void GrdPessoas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GrdPessoas.EditIndex != e.Row.RowIndex)
            {
                var data = (DataRowView)e.Row.DataItem;
                var foto = data["FOTO"];
                if (foto != DBNull.Value || foto.ToString().Length > 0)
                {
                    byte[] bytes = (byte[])(e.Row.DataItem as DataRowView)["FOTO"];
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    (e.Row.FindControl("Image1") as System.Web.UI.WebControls.Image).ImageUrl = "data:image/png;base64," + base64String;
                }
            }
        }
        protected void btnProcurar_Click(object sender, EventArgs e)
        {
            string varLike = txtProcurar.Text.Trim();
            string varEMPRESA = Label10.Text;
            MySqlCommand cmd = new MySqlCommand("Select * FROM PESSOAS WHERE EMPRESA='" + varEMPRESA + "' AND NOME LIKE @NOME ", conn);
            cmd.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
            cmd.Parameters.AddWithValue("@NOME", "%" + txtProcurar.Text.Trim() + "%");
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            GrdPessoas.DataSource = ds;
            GrdPessoas.DataBind();
            lbltotalcount.Text = GrdPessoas.Rows.Count.ToString();
            if (GrdPessoas.Rows.Count > 0)
                GrdPessoas.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void btnProcurar2_Click(object sender, EventArgs e)
        {
            string varLike2 = txtProcurar2.Text.Trim();
            string varEMPRESA = Label10.Text;
            MySqlCommand cmd = new MySqlCommand("Select * FROM QUALIFICACAO WHERE  EMPRESA='" + varEMPRESA + "' AND DESCRICAO LIKE '%" + varLike2 + "%' ", conn);
            cmd.Parameters.AddWithValue("@EMPRESA", varEMPRESA);
            cmd.Parameters.AddWithValue("@DESCRICAO", varLike2);
            MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            GrdQualificacao.DataSource = ds2;
            GrdQualificacao.DataBind();
            lbltotalcount2.Text = GrdQualificacao.Rows.Count.ToString();
            if (GrdQualificacao.Rows.Count > 0)
                GrdQualificacao.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void GrdListaPessoaQualificacao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GrdListaPessoaQualificacao.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GrdListaPessoaQualificacao.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GrdListaPessoaQualificacao.Style.Add("font-weight", "bold");
                GrdListaPessoaQualificacao.Columns[1].ItemStyle.ForeColor = Color.Red;
            }
        }
    }
}
