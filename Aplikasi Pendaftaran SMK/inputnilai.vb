Imports System.Data.Odbc
Public Class inputnilai
    Dim con As OdbcConnection
    Dim dr As OdbcDataReader
    Dim da As OdbcDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable
    Dim cmd As OdbcCommand
    Sub koneksi()
        con = New OdbcConnection
        con.ConnectionString = "dsn=siswa"
        con.Open()
    End Sub
    Sub simpan()
        koneksi()
        Dim sql As String = "insert into tbnilai values('" & ComboBox1.Text & "','" & TextBox5.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "')"
        cmd = New OdbcCommand(sql, con)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
        Catch ex As Exception
            MsgBox("Menyimpan data GAGAL", vbInformation, "PERINGATAN")
        End Try
    End Sub
    Sub daftar()
        koneksi()
        cmd = New OdbcCommand("select no from tbregist", con)
        dr = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        Do While dr.Read
            ComboBox1.Items.Add(dr.Item("no"))
        Loop
    End Sub
    Sub edit()
        koneksi()
        Dim update As String = "update tbnilai set id_test='" & TextBox5.Text & "', nama='" & TextBox1.Text & "',asal='" & TextBox2.Text & "',jurusan='" & TextBox3.Text & "',ruangan='" & TextBox4.Text & "',mtk='" & TextBox6.Text & "',bi='" & TextBox7.Text & "',bing='" & TextBox8.Text & "',kejuruan='" & TextBox9.Text & "',rata='" & TextBox10.Text & "',ket='" & TextBox11.Text & "'  where no='" & ComboBox1.Text & "'"
        cmd = New OdbcCommand(update, con)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Mengedit data BERHASIL", vbInformation, "INFORMASI")
        Catch ex As Exception
            MsgBox("Mengedit data GAGAL", vbInformation, "PERINGATAN")
        End Try
    End Sub
    Sub auto()
        koneksi()
        cmd = New OdbcCommand("select id_test from tbnilai order by no desc", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox5.Text = Val(Microsoft.VisualBasic.Mid(dr.Item("id_test"), 5, 4)) + 1
            If Len(TextBox5.Text) = 1 Then
                TextBox5.Text = "SOAL00" & TextBox5.Text & " "
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox5.Text = "SOAL0" & TextBox5.Text & " "
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox5.Text = "SOAL" & TextBox5.Text & " "
            End If
        Else
            TextBox5.Text = "SOAL00" + "1"

        End If
    End Sub



    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox5.Enabled = False
        auto()
        daftar()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        cmd = New OdbcCommand("select * from tbregist where no='" & ComboBox1.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox1.Text = dr.Item("nama")
            TextBox2.Text = dr.Item("asal")
            TextBox3.Text = dr.Item("jurusan")
            TextBox4.Text = dr.Item("ruangan")
        Else
            MsgBox("No.Daftar Siswa tidak ada")
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        Dim mtk As Integer
        Dim bi As Integer
        Dim bing As Integer
        Dim kjr As Integer
        Dim rata As Single
        mtk = CInt(TextBox6.Text)
        bi = CInt(TextBox7.Text)
        bing = CInt(TextBox8.Text)
        kjr = CInt(TextBox9.Text)
        rata = CSng((mtk + bi + kjr + bing) / 4)
        TextBox10.Text = rata
        If CSng(TextBox10.Text) >= 60 Then
            TextBox11.Text = "LULUS"
        Else
            TextBox11.Text = "TIDAK LULUS"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        simpan()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        auto()
        ComboBox1.Text = "--pilih--"
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox6.Text = "0"
        TextBox7.Text = "0"
        TextBox8.Text = "0"
        TextBox9.Text = "0"
        TextBox10.Text = "0"
        TextBox11.Text = ""
        ComboBox1.Focus()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        edit()
    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        cetakhasil.Show()
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click
 

    End Sub
End Class