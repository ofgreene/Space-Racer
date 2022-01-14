Public Class frmSpaceRacer
    Dim score As Double
    Dim ast(5) As PictureBox

    Private Sub frmSpaceRacer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ast(1) = pbAsteroid1
        ast(2) = pbAsteroid2
        ast(3) = pbAsteroid3
        ast(4) = pbAsteroid4
        ast(5) = pbAsteroid5
    End Sub

    Private Sub tmStarMover_Tick(sender As Object, e As EventArgs) Handles tmStarMover.Tick

        Dim asteroid = New Random()
        Dim nextAsteroid = asteroid.Next(1, 1000)

        Dim asteroidStart = New Random()
        Dim asteroidX = asteroidStart.Next(1, pnlDisplay.Width)

        For x As Integer = 1 To 5
            ast(x).BringToFront()
        Next

        If pbAsteroid1.Top >= 0 And pbAsteroid1.Top <= pnlDisplay.Height Then
            pbAsteroid1.Top += 20
        Else
            If nextAsteroid >= 0 And nextAsteroid <= 99 Then
                pbAsteroid1.Left = asteroidStart.Next(1, pnlDisplay.Width - pbAsteroid1.Width)
                pbAsteroid1.Top = 1
            End If
        End If

        If pbAsteroid2.Top >= 0 And pbAsteroid2.Top <= pnlDisplay.Height Then
            pbAsteroid2.Top += 40
        Else
            If nextAsteroid >= 100 And nextAsteroid <= 199 Then
                pbAsteroid2.Left = asteroidStart.Next(1, pnlDisplay.Width - pbAsteroid2.Width)
                pbAsteroid2.Top = 1
            End If
        End If

        If pbAsteroid3.Top >= 0 And pbAsteroid3.Top <= pnlDisplay.Height Then
            pbAsteroid3.Top += 50
        Else
            If nextAsteroid >= 200 And nextAsteroid <= 225 Then
                pbAsteroid3.Left = asteroidStart.Next(1, pnlDisplay.Width - pbAsteroid3.Width)
                pbAsteroid3.Top = 1
            End If
        End If

        If pbAsteroid4.Top >= 0 And pbAsteroid4.Top <= pnlDisplay.Height Then
            pbAsteroid4.Top += 30
        Else
            If nextAsteroid >= 300 And nextAsteroid <= 350 Then
                pbAsteroid4.Left = asteroidStart.Next(1, pnlDisplay.Width - pbAsteroid4.Width)
                pbAsteroid4.Top = 1
            End If
        End If

        If pbAsteroid5.Top >= 0 And pbAsteroid5.Top <= pnlDisplay.Height Then
            pbAsteroid5.Top += 30
        Else
            If nextAsteroid >= 400 And nextAsteroid <= 425 Then
                pbAsteroid5.Left = asteroidStart.Next(1, pnlDisplay.Width - pbAsteroid5.Width)
                pbAsteroid5.Top = 1
            End If
        End If

        For x As Integer = 1 To 5
            If (ast(x).Bounds.IntersectsWith(pbShip.Bounds)) Then
                gameover()
            End If
        Next

        pb1.Top += 5
        If pb1.Top >= Me.Height Then
            pb1.Top = 0
        End If
        pb2.Top += 10
        If pb2.Top >= Me.Height Then
            pb2.Top = 0
        End If
        pb3.Top += 10
        If pb3.Top >= Me.Height Then
            pb3.Top = 0
        End If
        pb4.Top += 10
        If pb4.Top >= Me.Height Then
            pb4.Top = 0
        End If
        pb5.Top += 5
        If pb5.Top >= Me.Height Then
            pb5.Top = 0
        End If
        pb6.Top += 10
        If pb6.Top >= Me.Height Then
            pb6.Top = 0
        End If
        pb7.Top += 5
        If pb7.Top >= Me.Height Then
            pb7.Top = 0
        End If
        pb8.Top += 2
        If pb8.Top >= Me.Height Then
            pb8.Top = 0
        End If
        pb9.Top += 1
        If pb9.Top >= Me.Height Then
            pb9.Top = 0
        End If
        pb10.Top += 1
        If pb10.Top >= Me.Height Then
            pb10.Top = Me.Top
        End If
        pb11.Top += 2
        If pb11.Top >= Me.Height Then
            pb11.Top = Me.Top
        End If
        pb12.Top += 10
        If pb12.Top >= Me.Height Then
            pb12.Top = Me.Top
        End If
        pb13.Top += 1
        If pb13.Top >= Me.Height Then
            pb13.Top = Me.Top
        End If
        pb14.Top += 10
        If pb14.Top >= Me.Height Then
            pb14.Top = Me.Top
        End If
        pb15.Top += 5
        If pb15.Top >= Me.Height Then
            pb15.Top = Me.Top
        End If
        pb16.Top += 5
        If pb16.Top >= Me.Height Then
            pb16.Top = Me.Top
        End If
        pb17.Top += 5
        If pb17.Top >= Me.Height Then
            pb17.Top = Me.Top
        End If
        pb18.Top += 1
        If pb18.Top >= Me.Height Then
            pb18.Top = Me.Top
        End If
        pb19.Top += 5
        If pb19.Top >= Me.Height Then
            pb19.Top = Me.Top
        End If
        pb20.Top += 5
        If pb20.Top >= Me.Height Then
            pb20.Top = Me.Top
        End If

        pbDistance.Top += 10
        score = pbDistance.Top
        txtScore.Text = score

    End Sub

    Private Sub gameover()
        tmStarMover.Enabled = False
        pbExplosion.Visible = True
        pbExplosion.Top = pbShip.Top - 60
        pbExplosion.Left = pbShip.Left - 60
        lblEndGame.Visible = True
        Dim Distance As Double = score / 1000
        txtDistance.Text = CStr(Distance) + " Light Years"
        For x As Integer = 1 To 5
            ast(x).SendToBack()
        Next
        pbLeft.Enabled = False
        pbRight.Enabled = False
        pbFaster.Enabled = False
        pbSlower.Enabled = False
        lstScoreboard.Items.Clear()

        Dim strScores() As String = {txtPlayerName.Text + " " + txtScore.Text}
        Dim strOutFile As String = "c:\\Users\ofgre\source\repos\\Space Racer - Copy\Space Racer\sScores.Text"

        Dim swOutFile As IO.StreamWriter
        swOutFile = IO.File.AppendText(strOutFile)
        For Each strScore In strScores
            swOutFile.WriteLine(strScore)
        Next
        swOutFile.Close()

        Dim strInFile As String = "c:\\Users\ofgre\source\repos\\Space Racer - Copy\Space Racer\sScores.Text"
        Dim strLine As String
        Dim srInFile As IO.StreamReader

        srInFile = IO.File.OpenText(strInFile)
        Do While Not srInFile.EndOfStream
            strLine = srInFile.ReadLine
            If strLine.Length() > 0 Then
                lstScoreboard.Items.Add(strLine)
            End If
        Loop
        srInFile.Close()

        txtPlayerName.Text = ""


    End Sub

    Private Sub pbStart_Click(sender As Object, e As EventArgs) Handles pbStart.Click

        If txtPlayerName.Text = "" Then
            tmStarMover.Enabled = False
        Else
            tmStarMover.Enabled = True
        End If

        tmStarMover.Interval = 200
        pbDistance.Top = 0
        pbAsteroid1.Visible = True
        pbAsteroid1.Top = 1
        pbAsteroid2.Visible = True
        pbAsteroid2.Top = 1
        pbAsteroid3.Visible = True
        pbAsteroid3.Top = 1
        pbAsteroid4.Visible = True
        pbAsteroid4.Top = 1
        pbAsteroid5.Visible = True
        pbAsteroid5.Top = 1
        txtScore.Text = ""
        txtDistance.Text = ""
        pbExplosion.Visible = False
        lblEndGame.Visible = False
        For x As Integer = 1 To 5
            ast(x).BringToFront()
        Next
        pbLeft.Enabled = True
        pbRight.Enabled = True
        pbFaster.Enabled = True
        pbSlower.Enabled = True


    End Sub
    Private Sub pbStop_Click(sender As Object, e As EventArgs) Handles pbStop.Click
        tmStarMover.Enabled = False
        pbAsteroid1.Visible = False
        pbAsteroid2.Visible = False
        pbAsteroid3.Visible = False
        pbAsteroid4.Visible = False
        pbAsteroid5.Visible = False
        Dim Distance As Double = score / 1000
        txtDistance.Text = CStr(Distance) + " Light Years"


    End Sub
    Private Sub pbFaster_Click(sender As Object, e As EventArgs) Handles pbFaster.Click
        If tmStarMover.Interval > 20 Then
            tmStarMover.Interval -= 20
        Else
            tmStarMover.Interval = 10
        End If
    End Sub

    Private Sub pbSlower_Click(sender As Object, e As EventArgs) Handles pbSlower.Click
        If tmStarMover.Interval < 200 Then
            tmStarMover.Interval += 10
        Else
            tmStarMover.Interval = 200
        End If
    End Sub

    Private Sub pbRight_Click(sender As Object, e As EventArgs) Handles pbRight.Click
        If pbShip.Right < pnlDisplay.Width - pbShip.Width Then
            pbShip.Left += 55
        Else
            pbShip.Left = pnlDisplay.Width - pbShip.Width
        End If

    End Sub

    Private Sub pbLeft_Click(sender As Object, e As EventArgs) Handles pbLeft.Click
        If pbShip.Left > pbShip.Width Then
            pbShip.Left -= 45
        Else
            pbShip.Left = 10
        End If
    End Sub
End Class
