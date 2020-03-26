Public Class Form_Menu

    Private Sub DAFTARSISWAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAFTARSISWAToolStripMenuItem.Click
        Daftar.Show()
    End Sub

    Private Sub REGISTRASIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REGISTRASIToolStripMenuItem.Click
        registrasi.Show()
    End Sub

    Private Sub NILAIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NILAIToolStripMenuItem.Click
        nilai.show()
    End Sub

    Private Sub PRINTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTToolStripMenuItem.Click
        print.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        End
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = Format(Now, "dd MMMM yyyy")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Jika terjadi Error Silahkan Hubungi Programer 085xxxxxx")
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class