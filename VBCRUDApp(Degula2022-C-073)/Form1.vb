Imports Microsoft.Win32

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open(constr)
        cmd.ActiveConnection = con
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            cmd.CommandText = "select * from UsersTable where uname = '" & txtUsername.Text & "' and pword = '" & txtPass.Text & "'"
            rs = cmd.Execute

            If rs.EOF = False Then
                MessageBox.Show("Logged in successfully!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.None)
                txtUsername.Text = ""
                txtPass.Text = ""
                Me.Hide()
                crudform.Show()
            ElseIf txtUsername.Text = "" And txtPass.Text = "" Then
                MessageBox.Show("Username and Password cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf txtPass.Text = "" Then
                MessageBox.Show("Password cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf txtUsername.Text = "" Then
                MessageBox.Show("Username cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf Not txtPass.Text = "from UsersTable where pword  = '" & txtPass.Text & "'" And Not txtUsername.Text = "from UsersTable where uname  = '" & txtUsername.Text & "'" Then
                MessageBox.Show("Username and Password does not exist. Register first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cleartxt()
            ElseIf Not txtPass.Text = "from UsersTable where pword  = '" & txtPass.Text & "'" Then
                MessageBox.Show("Password does not match any username. Try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cleartxt()
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReg_Click(sender As Object, e As EventArgs) Handles btnReg.Click
        Me.Hide()
        register.Show()
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
    Sub cleartxt()
        txtUsername.Clear()
        txtPass.Clear()
    End Sub
End Class
