Public Class register
    Sub cleartxt()
        txtUsername.Clear()
        txtPass.Clear()
        txtConfirm.Clear()
    End Sub
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Try
            cmd.CommandText = "select * from UsersTable where uname = '" & txtUsername.Text & "'"
            rs = cmd.Execute
            If rs.EOF = False Then
                MessageBox.Show("Account already exists! Try another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cleartxt()
            ElseIf txtUsername.Text = "" And txtPass.Text = "" Then
                MessageBox.Show("Username and Password cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf txtUsername.Text = "" Then
                MessageBox.Show("Username cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cleartxt()
            ElseIf txtPass.Text = "" Then
                MessageBox.Show("Password cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cleartxt()
            ElseIf txtConfirm.Text = "" Then
                MessageBox.Show("Password cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                cmd.CommandText = "insert into UsersTable (uname, pword) values ('" & txtUsername.Text & "', '" & txtPass.Text & "')"
                cmd.Execute()

                MessageBox.Show("Record added successfully! Please proceed to Login form", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cleartxt()
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub txtConfirm_TextChanged(sender As Object, e As EventArgs) Handles txtConfirm.TextChanged
        If Not txtConfirm.Text = txtPass.Text Then
            lblMatch.Text = "Password does not match!"
        Else
            lblMatch.Text = ""
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Me.Show()
        Else
            con.Close()
            Environment.Exit(0)
        End If
    End Sub
End Class