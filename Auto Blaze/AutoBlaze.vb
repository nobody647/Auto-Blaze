﻿Public Class AutoBlaze
    Dim Times As Integer = 0

    Private Sub BlazeButton_Click(sender As Object, e As EventArgs) Handles BlazeButton.Click
        Me.Blaze()
    End Sub

    Private Sub Blaze()
        My.Computer.Audio.Play(My.Resources.blaze, AudioPlayMode.Background)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ABTimed.Checked And (DateAndTime.Now.ToShortTimeString = "4:20 PM") Then
            Me.Blaze()
        ElseIf ABEvery.Checked
            Me.Blaze()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If LoadBar.Value = LoadBar.Maximum Then
            LoadBar.Value = LoadBar.Minimum
        End If
        LoadBar.Increment(LoadBar.Maximum / 60)
    End Sub

    Private Sub BlazeTimer_Tick(sender As Object, e As EventArgs) Handles BlazeTimer.Tick
        Times += 1

        If Times >= TickChooser.Text Then
            If ABTimed.Checked And (DateAndTime.Now.ToShortTimeString = TimeChooser.Text + " " + AMPMChooser.Text) Then
                Me.Blaze()
            ElseIf ABEvery.Checked
                Me.Blaze()
            End If

            Times = 0
            LoadBar.Value = LoadBar.Minimum
        End If

        If TickChooser.Text > 0 Then
            LoadBar.Value = Times * LoadBar.Maximum / TickChooser.Text
        End If
    End Sub

    Private Sub ABSuper_Click(sender As Object, e As EventArgs) Handles ABSuper.Click
        MessageBox.Show("Sorry, this feature is not yet implemented", "AutoBlaze")
        ABOff.Select()
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If WindowState.Minimized Then
            ShowInTaskbar = False
            NotifyIcon1.Visible = True
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        Me.WindowState = FormWindowState.Normal
        ShowInTaskbar = True
        NotifyIcon1.Visible = False
    End Sub

    Private Sub ReplaceEmpty(sender As Object, e As EventArgs) Handles TickChooser.TextChanged
        If TickChooser.Text = "" Then
            TickChooser.Text = 0
        End If
    End Sub

End Class