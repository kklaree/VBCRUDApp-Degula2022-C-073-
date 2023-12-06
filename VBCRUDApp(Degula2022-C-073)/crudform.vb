Imports System.Windows.Forms.AxHost
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class crudform
    Dim userstr As String
    Private Sub crudform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
    End Sub
    Sub loaddata()
        DataGridView1.Rows.Clear()
        cmd.CommandText = "Select uname from UsersTable"
        rs = cmd.Execute
        Do While Not rs.EOF
            DataGridView1.Rows.Add(rs.Fields(0).Value)
            rs.MoveNext()
        Loop
    End Sub

    Sub cleartxt()
        txtUsername.Clear()
        txtPass.Clear()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            cmd.CommandText = $"Select * from UsersTable where uname = '{txtUsername.Text}'"
            rs = cmd.Execute
            If rs.EOF = False Then
                MessageBox.Show("Username already exists! Try another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cleartxt()
                loaddata()
            ElseIf txtUsername.Text = "" And txtPass.Text = "" Then
                MessageBox.Show("Username and Password cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf txtPass.Text = "" Then
                MessageBox.Show("Password cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf txtUsername.Text = "" Then
                MessageBox.Show("Username cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                cmd.CommandText = "insert into UsersTable (uname, pword) values ('" & txtUsername.Text & "', '" & txtPass.Text & "')"
                cmd.Execute()

                MessageBox.Show("Record added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cleartxt()
                loaddata()
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the account?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Me.Show()
        Else
            Try
                cmd.CommandText = "delete from UsersTable where uname = '" & txtUsername.Text & "'"
                cmd.Execute()

                MessageBox.Show("Record deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cleartxt()
                loaddata()
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnUdate_Click(sender As Object, e As EventArgs) Handles btnUdate.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to edit your password?", "Edit confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Me.Show()
        Else
            Try
                If txtUsername.Text = "" And txtPass.Text = "" Then
                    MessageBox.Show("Username and Password cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf txtPass.Text = "" Then
                    MessageBox.Show("Password cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf txtUsername.Text = "" Then
                    MessageBox.Show("Username cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    cmd.CommandText = "update UsersTable set pword = '" & txtPass.Text & "' where uname = '" & txtUsername.Text & "' "
                    cmd.Execute()
                    MessageBox.Show("Password updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cleartxt()
                    loaddata()
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to Logout?", "Logout confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Me.Show()
        Else
            Me.Hide()
            Form1.Show()
        End If
    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Me.Show()
        Else
            con.Close()
            Environment.Exit(0)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Try
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If DataGridView1.SelectedRows.Count > 0 Then
                userstr = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
                txtUsername.Text = userstr
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cleartxt()
    End Sub
End Class
