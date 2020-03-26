Imports System.Data.Odbc
Public Class Input
    Dim con As OdbcConnection
    Dim dr As OdbcDataReader
    Dim da As OdbcDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable
    Dim cmd As OdbcCommand
    Dim Gender As String
    Friend Shared datetimepecker1 As Object

    Sub koneksi()
        con = New OdbcConnection
        con.ConnectionString = "dsn=siswa"
        con.Open()
    End Sub
    Sub simpan()
        koneksi()
        If RadioButton1.Checked = True Then
            Gender = "L"
        ElseIf RadioButton2.Checked = True Then
            Gender = "P"
        End If
        Dim sql As String = "insert into tbdaftar values('" & TextBox1.Text & "','" & Label1.Text & "','" & TextBox2.Text & "','" & Gender & "','" & TextBox3.Text & "','" & DateTimePicker1.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
        cmd = New OdbcCommand(sql, con)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
        Catch ex As Exception
            MsgBox("Menyimpan data GAGAL", vbInformation, "PERINGATAN")
        End Try
    End Sub
    Sub auto()
        koneksi()
        cmd = New OdbcCommand("select no from tbdaftar order by no desc", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(dr.Item("no"), 5, 4)) + 1
            If Len(TextBox1.Text) = 1 Then
                TextBox1.Text = "201800" & TextBox1.Text & " "
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox1.Text = "20180" & TextBox1.Text & " "
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox1.Text = "2018" & TextBox1.Text & " "
            End If
        Else
            TextBox1.Text = "201800" + "1"

        End If
    End Sub
    Sub edit()
        koneksi()
        If RadioButton1.Checked = True Then
            Gender = "L"
        ElseIf RadioButton2.Checked = True Then
            Gender = "P"
        End If
        Dim update As String = "update tbdaftar set tgl_daftar='" & Label1.Text & "', nama='" & TextBox2.Text & "',jenis='" & Gender & "',tempat='" & TextBox3.Text & "',tgl_lahir='" & DateTimePicker1.Text & "',asal='" & TextBox4.Text & "',agama='" & ComboBox1.Text & "',alamat='" & TextBox5.Text & "',nama_ortu='" & TextBox6.Text & "', pekerjaan='" & TextBox7.Text & "'  where no='" & TextBox1.Text & "'"
        cmd = New OdbcCommand(update, con)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Mengedit data BERHASIL", vbInformation, "INFORMASI")
        Catch ex As Exception
            MsgBox("Mengedit data GAGAL", vbInformation, "PERINGATAN")
        End Try
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        Label1.Text = Format(Now, "dd MMMM yyyy")
        auto()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        simpan()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        auto()
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = "--pilih--"
        TextBox1.Focus()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        edit()
    End Sub
End Class