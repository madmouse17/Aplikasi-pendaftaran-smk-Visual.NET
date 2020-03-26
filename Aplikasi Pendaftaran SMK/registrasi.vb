Imports System.Data.Odbc
Public Class registrasi
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
        Dim sql As String = "insert into tbregist values('" & ComboBox1.Text & "','" & TextBox1.Text & "','" & TextBox5.Text & "','" & ComboBox2.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
        cmd = New OdbcCommand(sql, con)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
        Catch ex As Exception
            MsgBox("Menyimpan data GAGAL", vbInformation, "PERINGATAN")
        End Try
    End Sub
    Sub tampil()
        DataGridView1.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select *from tbregist order by no asc", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView1.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try
    End Sub
    Sub daftar()
        cmd = New OdbcCommand("select no from tbdaftar", con)
        dr = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        Do While dr.Read
            ComboBox1.Items.Add(dr.Item("no"))
        Loop
    End Sub
    Sub edit()
        koneksi()
        Dim update As String = "update tbregist set nama='" & TextBox1.Text & "', asal='" & TextBox5.Text & "',jurusan='" & ComboBox2.Text & "',ruangan='" & TextBox2.Text & "',guru='" & TextBox3.Text & "',registrasi='" & TextBox4.Text & "'  where no='" & ComboBox1.Text & "'"
        cmd = New OdbcCommand(update, con)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Mengedit data BERHASIL", vbInformation, "INFORMASI")
        Catch ex As Exception
            MsgBox("Mengedit data GAGAL", vbInformation, "PERINGATAN")
        End Try
        tampil()
    End Sub


    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampil()
        daftar()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        cmd = New OdbcCommand("select * from tbdaftar where no='" & ComboBox1.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox1.Text = dr.Item("nama")
            TextBox5.Text = dr.Item("asal")
        Else
            MsgBox("No.Daftar Siswa tidak ada")
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "Tata Boga" Then
            TextBox2.Text = "3"
            TextBox3.Text = "Sumaryani Spd"
            TextBox4.Text = "200.000"
        ElseIf ComboBox2.Text = "Multimedia" Then
            TextBox2.Text = "LAB Multimedia"
            TextBox3.Text = "Djoko Santoso Spd"
            TextBox4.Text = "200.000"
        ElseIf ComboBox2.Text = "TKJ" Then
            TextBox2.Text = " LAB 3"
            TextBox3.Text = "Darmawan S.Kom"
            TextBox4.Text = "200.000"
        ElseIf ComboBox2.Text = "Akutansi" Then
            TextBox2.Text = "5"
            TextBox3.Text = "Sumarlina Spd"
            TextBox4.Text = "200.000"

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        tampil()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        simpan()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim a As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        If a = "" Then
            MsgBox("Data Pemilihan Jurusan yang dihapus belum DIPILIH")
        Else

        End If
        If (MessageBox.Show("Anda yakin menghapus data pemilihan jurusan dengan no=" & a & "...?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK) Then
            koneksi()
            cmd = New OdbcCommand("delete from tbregist where no='" & a & "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("Menghapus data nilai BERHASIL", vbInformation, "INFORMASI")
            con.Close()
            tampil()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        kartutest.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ComboBox1.Text = "--pilih--"
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox2.Text = "--pilih--"
        ComboBox1.Focus()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick


        Dim index As Integer
        index = e.RowIndex

        Dim selectedrow As DataGridViewRow

        selectedrow = DataGridView1.Rows(index)

        ComboBox1.Text = selectedrow.Cells(0).Value.ToString()
        TextBox1.Text = selectedrow.Cells(1).Value.ToString()
        TextBox5.Text = selectedrow.Cells(2).Value.ToString()
        ComboBox2.Text = selectedrow.Cells(3).Value.ToString()
        TextBox2.Text = selectedrow.Cells(4).Value.ToString()
        TextBox3.Text = selectedrow.Cells(5).Value.ToString()
        TextBox4.Text = selectedrow.Cells(6).Value.ToString()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        edit()
    End Sub
End Class