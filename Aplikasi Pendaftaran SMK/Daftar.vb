Imports System.Data.Odbc
Public Class Daftar
    Dim con As OdbcConnection
    Dim dr As OdbcDataReader
    Dim da As OdbcDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable
    Dim cmd As OdbcCommand

    Private Property Gender As String

    Sub koneksi()
        con = New OdbcConnection
        con.ConnectionString = "dsn=siswa"
        con.Open()
    End Sub
    Sub tampil()
        DataGridView1.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select *from tbdaftar order by no asc", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView1.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), row(10))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampil()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Input.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tampil()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim a As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        If a = "" Then
            MsgBox("Data Siswa yang dihapus belum DIPILIH")
        Else
            If (MessageBox.Show("Anda yakin menghapus data siswa dengan no.daftar=" & a & "...?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK) Then
                koneksi()
                cmd = New OdbcCommand("delete from tbdaftar where no='" & a & "'", con)
                cmd.ExecuteNonQuery()
                MsgBox("Menghapus data BERHASIL", vbInformation, "INFORMASI")
                con.Close()
                tampil()
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Function Sql() As Object
        Throw New NotImplementedException
    End Function

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Input.Show()
       
        Dim index As Integer
        index = e.RowIndex

        Dim selectedrow As DataGridViewRow

        SelectedRow = DataGridView1.Rows(index)

        Input.TextBox1.Text = selectedrow.Cells(0).Value.ToString()
        Input.Label1.Text = selectedrow.Cells(1).Value.ToString()
        Input.TextBox2.Text = selectedrow.Cells(2).Value.ToString()
        If selectedrow.Cells(3).Value.ToString = "L" Then
            Input.RadioButton1.Checked = True
        Else
            Input.RadioButton2.Checked = True
        End If
        
        Input.TextBox3.Text = selectedrow.Cells(4).Value.ToString()
        Input.DateTimePicker1.Text = selectedrow.Cells(5).Value.ToString()
        Input.TextBox4.Text = selectedrow.Cells(6).Value.ToString()
        Input.ComboBox1.Text = selectedrow.Cells(7).Value.ToString()
        Input.TextBox5.Text = selectedrow.Cells(8).Value.ToString()
        Input.TextBox6.Text = selectedrow.Cells(9).Value.ToString()
        Input.TextBox7.Text = selectedrow.Cells(10).Value.ToString()

    End Sub


End Class