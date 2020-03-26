Imports System.Data.Odbc
Imports Microsoft.Reporting.WinForms
Public Class cetakhasil
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
        Dim sql As String = "insert into tbnilai values('" & inputnilai.ComboBox1.Text & "','" & inputnilai.TextBox5.Text & "','" & inputnilai.TextBox1.Text & "','" & inputnilai.TextBox2.Text & "','" & inputnilai.TextBox3.Text & "','" & inputnilai.TextBox4.Text & "','" & inputnilai.TextBox6.Text & "','" & inputnilai.TextBox7.Text & "','" & inputnilai.TextBox8.Text & "','" & inputnilai.TextBox9.Text & "','" & inputnilai.TextBox10.Text & "','" & inputnilai.TextBox11.Text & "')"
        cmd = New OdbcCommand(sql, con)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
        Catch ex As Exception
            MsgBox("Menyimpan data GAGAL", vbInformation, "PERINGATAN")
        End Try
    End Sub

    Private Sub cetakhasil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim no As New ReportParameter("no", inputnilai.ComboBox1.Text)
        Me.ReportViewer1.LocalReport.SetParameters(no)
        Dim nama As New ReportParameter("nama", inputnilai.TextBox1.Text)
        Me.ReportViewer1.LocalReport.SetParameters(nama)
        Dim asal As New ReportParameter("asal", inputnilai.TextBox2.Text)
        Me.ReportViewer1.LocalReport.SetParameters(asal)
        Dim jurusan As New ReportParameter("jurusan", inputnilai.TextBox3.Text)
        Me.ReportViewer1.LocalReport.SetParameters(jurusan)
        Dim ruangan As New ReportParameter("ruangan", inputnilai.TextBox4.Text)
        Me.ReportViewer1.LocalReport.SetParameters(ruangan)
        Dim id As New ReportParameter("id", inputnilai.TextBox5.Text)
        Me.ReportViewer1.LocalReport.SetParameters(id)
        Dim mtk As New ReportParameter("mtk", inputnilai.TextBox6.Text)
        Me.ReportViewer1.LocalReport.SetParameters(mtk)
        Dim bindo As New ReportParameter("bindo", inputnilai.TextBox7.Text)
        Me.ReportViewer1.LocalReport.SetParameters(bindo)
        Dim bing As New ReportParameter("bing", inputnilai.TextBox8.Text)
        Me.ReportViewer1.LocalReport.SetParameters(bing)
        Dim kejuruan As New ReportParameter("kejuruan", inputnilai.TextBox9.Text)
        Me.ReportViewer1.LocalReport.SetParameters(kejuruan)
        Dim rata As New ReportParameter("rata", inputnilai.TextBox10.Text)
        Me.ReportViewer1.LocalReport.SetParameters(rata)
        Dim ket As New ReportParameter("ket", inputnilai.TextBox11.Text)
        Me.ReportViewer1.LocalReport.SetParameters(ket)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        simpan()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class