Imports System.Data.Odbc
Imports Microsoft.Reporting.WinForms
Public Class kartutest
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
        Dim sql As String = "insert into tbregist values('" & registrasi.ComboBox1.Text & "','" & registrasi.TextBox1.Text & "','" & registrasi.TextBox5.Text & "','" & registrasi.ComboBox2.Text & "','" & registrasi.TextBox2.Text & "','" & registrasi.TextBox3.Text & "','" & registrasi.TextBox4.Text & "')"
        cmd = New OdbcCommand(sql, con)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
        Catch ex As Exception
            MsgBox("Menyimpan data GAGAL", vbInformation, "PERINGATAN")
        End Try
    End Sub

    Private Sub kartutest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim no As New ReportParameter("no", registrasi.ComboBox1.Text)
        Me.ReportViewer1.LocalReport.SetParameters(no)
        Dim nama As New ReportParameter("nama", registrasi.TextBox1.Text)
        Me.ReportViewer1.LocalReport.SetParameters(nama)
        Dim asal As New ReportParameter("asal", registrasi.TextBox5.Text)
        Me.ReportViewer1.LocalReport.SetParameters(asal)
        Dim jurusan As New ReportParameter("jurusan", registrasi.ComboBox2.Text)
        Me.ReportViewer1.LocalReport.SetParameters(jurusan)
        Dim ruangan As New ReportParameter("ruangan", registrasi.TextBox2.Text)
        Me.ReportViewer1.LocalReport.SetParameters(ruangan)
        Dim guru As New ReportParameter("guru", registrasi.TextBox3.Text)
        Me.ReportViewer1.LocalReport.SetParameters(guru)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        simpan()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class