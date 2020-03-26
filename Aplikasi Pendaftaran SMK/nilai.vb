Imports System.Data.Odbc
Public Class Nilai
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
    Sub tampil()
        DataGridView1.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select *from tbnilai order by no asc", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView1.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), row(10), row(11))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        inputnilai.Show()
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampil()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tampil()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim a As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        If a = "" Then
            MsgBox("Data Nilai yang dihapus belum DIPILIH")
        Else

        End If
        If (MessageBox.Show("Anda yakin menghapus data dengan no=" & a & "...?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK) Then
            koneksi()
            cmd = New OdbcCommand("delete from tbnilai where no='" & a & "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("Menghapus data nilai BERHASIL", vbInformation, "INFORMASI")
            con.Close()
            tampil()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        inputnilai.Show()

        Dim index As Integer
        index = e.RowIndex

        Dim selectedrow As DataGridViewRow

        selectedrow = DataGridView1.Rows(index)

        inputnilai.ComboBox1.Text = selectedrow.Cells(0).Value.ToString()
        inputnilai.TextBox5.Text = selectedrow.Cells(1).Value.ToString()
        inputnilai.TextBox1.Text = selectedrow.Cells(2).Value.ToString()
        inputnilai.TextBox2.Text = selectedrow.Cells(3).Value.ToString()
        inputnilai.TextBox3.Text = selectedrow.Cells(4).Value.ToString()
        inputnilai.TextBox4.Text = selectedrow.Cells(5).Value.ToString()
        inputnilai.TextBox6.Text = selectedrow.Cells(6).Value.ToString()
        inputnilai.TextBox7.Text = selectedrow.Cells(7).Value.ToString()
        inputnilai.TextBox8.Text = selectedrow.Cells(8).Value.ToString()
        inputnilai.TextBox9.Text = selectedrow.Cells(9).Value.ToString()
        inputnilai.TextBox10.Text = selectedrow.Cells(10).Value.ToString()
        inputnilai.TextBox11.Text = selectedrow.Cells(11).Value.ToString()

    End Sub


End Class