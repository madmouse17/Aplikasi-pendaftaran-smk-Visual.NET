Imports System.Data.Odbc
Public Class Login
    Dim con As OdbcConnection
    Dim dr As OdbcDataReader
    Dim da As OdbcDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable
    Dim cmd As OdbcCommand
    Dim sql As String
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con = New OdbcConnection
        con.ConnectionString = "dsn=siswa"
        con.Open()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sql = "select * from tblogin where username='" & TextBox1.Text & "' and password=MD5('" & TextBox2.Text & "')"
        cmd = New Odbc.OdbcCommand(sql, con)
        dr = cmd.ExecuteReader
        If dr.Read = False Then
            MsgBox("Mohon Periksa Kembali User dan Password, karena tidak terdaftar disistem ini")
        Else
            MsgBox("Selamat Login Berhasil")
            Form_Menu.Show()
        End If
    End Sub

    Private Sub TextBox2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.Enter

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
