<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Simples._Default" %>

<asp:Content ID="pessoas" ContentPlaceHolderID="MainContent" runat="server">
         <asp:Menu ID="tabMenu" runat="server" Orientation="Horizontal" 
             OnMenuItemClick="tabMenu_MenuItemClick" StaticDisplayLevels="2" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" StaticSubMenuIndent="10px"> 
             <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
             <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
             <DynamicMenuStyle BackColor="#B5C7DE" />
             <DynamicSelectedStyle BackColor="#507CD1" />
             <DynamicItemTemplate>
                 <%# Eval("Text") %>
             </DynamicItemTemplate>
            <Items>
                <asp:MenuItem Text="Cadastro" Value="t1" />
                <asp:MenuItem Text="Consulta" Value="t2" />
                <asp:MenuItem Text="Qualificacao" Value="t3" />
                <asp:MenuItem Text="Classificação" Value="t4" />
            </Items>
            <StaticMenuStyle CssClass="tab" />
             <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
            <StaticMenuItemStyle CssClass="item" HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle CssClass="selectedTab" BackColor="#507CD1" />
        </asp:Menu>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
             <div class="conteudo">
                   <div class="header">
                        <div class="title">
                            <h3>Cadastro de Pessoas</h3>
                        </div>
                    </div>   
                    <asp:Label ID="lblSID"  runat="server" ForeColor ="Black"  Visible ="false"></asp:Label>
                    <asp:Label ID="Label10" runat="server" Visible="False"></asp:Label>
                    <table>
                         <tr>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode="Conditional" >
                                <ContentTemplate>
                                 <td class="style14">
                                     <asp:Image ID="Image1" runat="server" Height="153px" Width="194px" />
                                 </td>
                                 <td class="style14">
                                     <asp:FileUpload ID="FileUploadControl" runat="server" onchange="showPreview(this);" AllowMultiple="False"/>
                                 </td>
                                 <td class="style14">
                                     <asp:Label ID="StatusLabel" runat="server"></asp:Label>
                                 </td>
                                 <br />   
                                 <td class="style14">
                                    <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" Text="Gravar Foto" />
                                 </td>
                                    <script type="text/javascript">

                                        function showPreview(input) {
                                            if (input.files && input.files[0]) {
                                                var reader = new FileReader();

                                                reader.onload = function (e) {
                                                    var img = document.getElementById('<%= Image1.ClientID %>');
                                                    img.src = e.target.result;
                                                    img.style.display = 'block'; 
                                                }

                                                reader.readAsDataURL(input.files[0]);
                                            }
                                        }
                                    </script>
                                </ContentTemplate>
                             </asp:UpdatePanel>
                         </tr>
                        <tr>
                            <td class="style15">QUALIFICAÇÃO</td>
                            <td class="style16">
                                <asp:Button ID="btnPesquisa1" runat="server" OnClick="btnPesquisa1_Click" 
                                    Text="Selecionar" />
                                <asp:TextBox ID="txtQUALIFICACAO" runat="server" Height="23px" Width="111px"></asp:TextBox>
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15">NOME</td>
                            <td class="style16">
                                <asp:TextBox ID="txtNOME" MaxLength="100" runat="server" Width="438px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td">EMAIL</td>
                            <td class="style14">
                                <asp:TextBox ID="txtEMAIL" MaxLength="50" runat="server" Width="363px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td">CNPJ</td>
                            <td class="style14">
                                <asp:TextBox ID="txtCNPJ" MaxLength="18" runat="server" Width="204px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td">ENDERECO</td>
                            <td class="style14">
                                <asp:TextBox ID="txtENDERECO" MaxLength="60" runat="server" Width="403px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td">NUMERO</td>
                            <td class="style14">
                                <asp:TextBox ID="txtNUMERO" MaxLength="6" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td">COMPLEMENTO</td>
                            <td class="style14">
                                <asp:TextBox ID="txtCOMPLEMENTO" MaxLength="100" runat="server" Width="206px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td">BAIRRO</td>
                            <td class="style14">
                                <asp:TextBox ID="txtBAIRRO" MaxLength="60" runat="server" Width="204px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td">CIDADE</td>
                            <td class="style14">
                                <asp:TextBox ID="txtCIDADE"  MaxLength="60" runat="server" Width="243px"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td class="td">CEP</td>
                            <td class="style14">
                                <asp:TextBox ID="txtCEP"  MaxLength="9" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td">PAIS</td>
                            <td class="style14">
                                <asp:TextBox ID="txtPAIS" MaxLength="20" runat="server" Width="182px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td">TELEFONE</td>
                            <td class="style14">
                                <asp:TextBox ID="txtTELEFONE" MaxLength="14" runat="server" Width="182px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td">CELULAR</td>
                            <td class="style14">
                                <asp:TextBox ID="txtCELULAR" MaxLength="15" onkeyup="formataCelular(this,event);" runat="server" Width="182px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style14">
                                <asp:Button ID="btnSubmit" runat="server" ValidationGroup="g" Text="Gravar" font-names="Tahoma" 
                                        tabindex="5" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnUpdate" runat="server" ValidationGroup="g" Text="Alterar"  font-names="Tahoma" 
                                    tabindex="5" Visible="false" OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnCancel" runat="server" font-names="Tahoma" 
                                        OnClick="btnCancel_Click" tabindex="5" 
                                    Text="Cancelar" />
                            </td>
                        </tr>
                    </table>
           </div>
            </asp:View>          
            <asp:View ID="View2" runat="server">              
                <div class="conteudo">
                    <div class="header">
                        <div class="title">
                            <h3>Selecionar a Pessoa </h3>
                            <p>&nbsp;</p>                    
                        </div>
                    </div>  
                    <table>             
                        <tr>
                            <td>Total Registros: <asp:Label ID="lbltotalcount" runat="server" Font-Bold="true"></asp:Label></td>
                        </tr>
                        <tr>        
                            <td><asp:Label ID="Label4" runat="server" Text="Busca Aproximada"></asp:Label></td>
                        </tr>
                        <tr>    
                            <td> <asp:TextBox ID="txtProcurar" runat="server"></asp:TextBox> </td>
                            <td><asp:Button ID="btnProcurar" runat="server" onclick="btnProcurar_Click" Text="Filtrar" /></td> 
                        </tr>
                    </table>
                    <asp:GridView ID="GrdPessoas" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" BorderColor="Black" BorderStyle="None" 
                        BorderWidth="1px" CellPadding="4" DataKeyNames="CODIGO, EMPRESA, QUALIFICACAO, ENDERECO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, CEP, PAIS, TELEFONE, CELULAR" 
                        EnableModelValidation="True" GridLines="Horizontal" 
                        onpageindexchanging="GrdPessoas_PageIndexChanging" 
                        OnRowDataBound="GrdPessoas_RowDataBound" OnRowDeleting="GrdPessoas_RowDeleting" 
                        OnSelectedIndexChanged="GrdPessoas_SelectedIndexChanged" pagesize="10" 
                        Width="750px">
                        <RowStyle BackColor="#CCCCCC" ForeColor="#4A3C8C" />
                        <Columns>
                            <asp:BoundField DataField="CODIGO" HeaderText="Código" HtmlEncode="False"  Visible="false"
                                NullDisplayText=" " SortExpression="CODIGO" />
                            <asp:CommandField HeaderText="Alterar" ShowSelectButton="True" />
                            <asp:CommandField HeaderText="Deletar" ShowDeleteButton="True" />
                            <asp:BoundField DataField="EMPRESA" HeaderText="Empresa" HtmlEncode="False" 
                                NullDisplayText=" " SortExpression="EMPRESA" Visible="false" />
                            <asp:BoundField DataField="QUALIFICACAO" HeaderText="Qualificação" 
                                HtmlEncode="False" NullDisplayText=" " SortExpression="QUALIFICACAO" 
                                Visible="false" />
                            <asp:BoundField DataField="NOME" HeaderText="Pessoa" NullDisplayText=" " 
                                SortExpression="NOME" />
                            <asp:BoundField DataField="EMAIL" HeaderText="Email" NullDisplayText=" " 
                                SortExpression="EMAIL" />
                            <asp:BoundField DataField="CNPJ" HeaderText="Cnpj" NullDisplayText=" " 
                                SortExpression="CNPJ" />
                            <asp:BoundField DataField="ENDERECO" HeaderText="Endereço" NullDisplayText=" " HtmlEncode="False"  Visible="false"
                                SortExpression="ENDERECO" />
                            <asp:BoundField DataField="NUMERO" HeaderText="Numero" NullDisplayText=" " HtmlEncode="False"  Visible="false"
                                SortExpression="NUMERO" />
                            <asp:BoundField DataField="COMPLEMENTO" HeaderText="Complemento" HtmlEncode="False"  Visible="false"
                                NullDisplayText=" " SortExpression="COMPLEMENTO" />
                            <asp:BoundField DataField="BAIRRO" HeaderText="Bairro" NullDisplayText=" " HtmlEncode="False"  Visible="false"
                                SortExpression="BAIRRO" />
                            <asp:BoundField DataField="CIDADE" HeaderText="Cidade" NullDisplayText=" " HtmlEncode="False"  Visible="false"
                                SortExpression="CIDADE" />
                            <asp:BoundField DataField="CEP" HeaderText="Cep" NullDisplayText=" " HtmlEncode="False"  Visible="false"
                                SortExpression="CEP" />
                            <asp:BoundField DataField="PAIS" HeaderText="Pais" NullDisplayText=" " HtmlEncode="False"  Visible="false"
                                SortExpression="PAIS" />
                            <asp:BoundField DataField="TELEFONE" HeaderText="Telefone" NullDisplayText=" " HtmlEncode="False"  Visible="false"
                                SortExpression="TELEFONE" />
                            <asp:BoundField DataField="CELULAR" HeaderText="Celular" NullDisplayText=" " HtmlEncode="False"  Visible="false"
                                SortExpression="CELULAR"  />
                            <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Height="80" Width="80" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            Não Existe Informações Registradas
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#333333" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="Black" Font-Bold="True" ForeColor="#F7F7F7" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="#F7F7F7" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle Font-Size="Smaller" />
                        <PagerSettings FirstPageText="<img src='Icones/first.png' border='0' title='Primeira Página'/&gt;" 
                            LastPageText="<img src='icones/last.png' border='0' title='Última Página'/&gt;" 
                            Mode="NextPreviousFirstLast" 
                            NextPageText="<img src='icones/next.png' border='0' title='Próxima Página'/&gt;" 
                            PageButtonCount="15" Position="Bottom" 
                            PreviousPageText="<img src='icones/previous.png' border='0' title='Página Anterior'/&gt;" />
                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="View3" runat="server">   
                <div class="conteudo">
                    <div class="header">
                        <div class="title">
                            <h3>Selecionar a Qualificação</h3>
                            <p>&nbsp;</p>                    
                        </div>
                    </div>
                         <table>             
                        <tr>
                            <td>Total Registros: <asp:Label ID="lbltotalcount2" runat="server" Font-Bold="True"></asp:Label></asp:Label></td>
                        </tr>
                        <tr>        
                            <td><asp:Label ID="Label5" runat="server" Text="Busca Aproximada"></asp:Label></td>
                        </tr>
                        <tr>    
                            <td><asp:TextBox ID="txtProcurar2" runat="server"></asp:TextBox></td>
                            <td><asp:Button ID="btnProcurar2" runat="server" onclick="btnProcurar2_Click" Text="Filtrar" /></td> 
                        </tr>
                    </table>
                    <asp:GridView ID="GrdQualificacao" runat="server" DataKeyNames="CODIGO" 
                        AutoGenerateColumns="False"  BorderColor="Black" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4"  Width="750px" GridLines="None" class="FixedTables"
                        OnSelectedIndexChanged="GrdQualificacao_SelectedIndexChanged" onpageindexchanging="GrdQualificacao_PageIndexChanging"
                        pagesize="10"  AllowPaging="True" EnableModelValidation="True">
                        <RowStyle BackColor="#CCCCCC" ForeColor="#4A3C8C" />
                        <Columns>
                        <asp:BoundField DataField="CODIGO" HeaderText="Código"  HtmlEncode="False" Visible="false" NullDisplayText=" " SortExpression="CODIGO" />
                        <asp:CommandField HeaderText="Selecionar" ShowSelectButton="True" />
                        <asp:BoundField DataField="EMPRESA" HeaderText="Empresa" HtmlEncode="False" Visible="false" NullDisplayText=" " SortExpression="EMPRESA" />
                        <asp:BoundField DataField="DESCRICAO" HeaderText="Qualificação"  NullDisplayText=" "  SortExpression="DESCRICAO" />
                        </Columns>
                        <EmptyDataTemplate>
                                Não Existe Informações Registradas 
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#333333" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="Black" Font-Bold="True" ForeColor="#F7F7F7" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="#F7F7F7" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle Font-Size="Smaller" />
                        <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast"
                        PreviousPageText="<img src='icones/previous.png' border='0' title='Página Anterior'/>"
                        NextPageText="<img src='icones/next.png' border='0' title='Próxima Página'/>"
                        FirstPageText="<img src='icones/first.png' border='0' title='Primeira Página'/>"
                        LastPageText="<img src='icones/last.png' border='0' title='Última Página'/>" PageButtonCount="15" />

                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="View4" runat="server">  
                <div class="conteudo"> 
                    <div class="header">
                        <div class="title">
                            <h3>Lista de Qualificação</h3>
                            <p>&nbsp;</p>                    
                        </div>
                    </div>     
                    <asp:GridView ID="GrdListaPessoaQualificacao" AutoGenerateColumns="False"  BorderColor="Black" 
                            BorderStyle="None" BorderWidth="1px" Width="750px" CellPadding="4" GridLines="None" class="FixedTables"
                        runat = "server"  OnDataBound="OnDataBound" pagesize="10"  AllowPaging="True" EnableModelValidation="True" OnRowDataBound="GrdListaPessoaQualificacao_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="QUALIFICACAO"  HeaderText="Qualificação" NullDisplayText=" "  />
                            <asp:BoundField DataField="NOME"  HeaderText="Pessoa" NullDisplayText=" "  />
                            </Columns>
                            <EmptyDataTemplate>
                                    Não Existe Informações Registradas 
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#333333" ForeColor="#4A3C8C" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="Black" Font-Bold="True" ForeColor="#F7F7F7" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="#F7F7F7" />
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle Font-Size="Smaller" />
                            <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast"
                            PreviousPageText="<img src='icones/previous.png' border='0' title='Página Anterior'/>"
                            NextPageText="<img src='icones/next.png' border='0' title='Próxima Página'/>"
                            FirstPageText="<img src='icones/first.png' border='0' title='Primeira Página'/>"
                            LastPageText="<img src='icones/last.png' border='0' title='Última Página'/>" PageButtonCount="15" />
                    </asp:GridView>
                </div>
            </asp:View>
        </asp:MultiView>
</asp:Content>

