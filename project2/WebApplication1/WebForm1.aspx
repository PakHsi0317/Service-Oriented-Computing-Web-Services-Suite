<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .noborder {
            margin-bottom: 8px;
        }

p {
  margin-top: 0;
  margin-bottom: 1rem;
}

* {
  box-sizing: border-box;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            WordCount<br />
            <br />
            Analyze a large text file and return a string of JSON data.<br />
            URL of the service: <a href="http://webstrar33.fulton.asu.edu/page6/Service1.svc">http://webstrar33.fulton.asu.edu/page6/Service1.svc</a> <br />
            Method(Operation) name: WordCount1<br />
            Parameter Type List: Stream fileStream<br />
            Return Type: string<br />
            Please choose a file form Location:
            <asp:FileUpload ID="FileUpload1" runat="server" Width="554px" />
        </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        Display key-value pairs here:<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Convert" Height="36px" style="margin-top: 0px" Width="105px" />
        <br />
        <textarea id="TextArea1" runat="server" cols="20" name="S1" rows="2"></textarea><br />
        <br />
        <br />
        Number2Words<br />
        <br />
        Convert a number, e.g., a phone number, into an easy-to-remember character/digit string.<br />
        URL of the service: <a href="http://webstrar33.fulton.asu.edu/page6/Service1.svc">http://webstrar33.fulton.asu.edu/page6/Service1.svc</a> <br />
        Method(Operation) name: Number2Words<br />
        Parameter Type List: string number<br />
        Return Type: string<br />
        EX: You can type in 278, and it will give you &#39;ASU&#39; back. Because &#39;ASU&#39; belongs to my dictionary set.<br />
        Please enter a sequnce of digit: <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" Width="474px"></asp:TextBox>
&nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Easy-words" />
        <br />
        Here is your easy-words:
        <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged" Width="473px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        Service WsdlAddress<br />
        <br />
        Analyze a webpage and return all WSDL address in that webpage in an array of strings.<br />
        URL of the service: <a href="http://webstrar33.fulton.asu.edu/page6/Service1.svc">http://webstrar33.fulton.asu.edu/page6/Service1.svc</a> <br />
        Method(Operation) name: getWsdlAddress<br />
        Parameter Type List: string url<br />
        Return Type: string[]<br />
        Please enter a URl(had better .html file)<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="502px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Height="36px" OnClick="Button2_Click" Text="Analyze" Width="102px" />
        <br />
        Display WSDL address here:<br />
        <asp:ListBox ID="ListBox1" runat="server" Height="444px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="1045px"></asp:ListBox>
        <br />
        <br />
        WsOperations Service<br />
        Convert a number, e.g., a phone number, into an easy-to-remember character/digit string.<br />
        URL of the service: <a href="http://webstrar33.fulton.asu.edu/page6/Service1.svc">http://webstrar33.fulton.asu.edu/page6/Service1.svc</a><br />
        Method(Operation) name:GetWsOperations<br />
        Parameter Type List: string url<br />
        Return Type: string[]<br />
        <br />
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Button" />
        <br />
        <br />
        <asp:ListBox ID="ListBox2" runat="server" Height="206px" Width="1054px"></asp:ListBox>
        <br />
        <br />
        <br />
        <br />
        Convert service <p>
        Convert morse code and char, vice versa.<br />
        URL of the service: <a href="http://webstrar33.fulton.asu.edu/page6/Service1.svc">http://webstrar33.fulton.asu.edu/page6/</a>WebForm1.aspx <br />
            Method(Operation) name: TomorseCode</p>
        <p>
            <br />
        Parameter Type List: string number<br />
        Return Type: string</p>
        <p>
            Morse To Code(You need to put the morse code and put a space between them)</p>
        <p>
            (For example. -- .-.- -. .-. -- .-- ) <p>
            You will get the result</p>
        <p>
            (MNRMW)</p>
        <p>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click1" Text="Button" />
        </p>
        <p>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        </p>
        Convert a number, e.g., a phone number, into an easy-to-remember character/digit string.<br />
        URL of the service: <a href="http://webstrar33.fulton.asu.edu/page6/Service1.svc">http://webstrar33.fulton.asu.edu/page5/Service1.svc</a> <br />
        Method(Operation) name: Encode, Decode<br />
        Parameter Type List: string number<br />
        Return Type: string<br />
        <p>
            Code To Morse(You can only input Upper alphabet string so far)</p>
        <p>
            <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox4_TextChanged" Width="446px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button5" runat="server" OnClick="Button3_Click" Text="Button" />
        </p>
        <p>
            <asp:TextBox ID="TextBox5" runat="server" Columns="50"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <br />
    </form>
</body>
</html>
