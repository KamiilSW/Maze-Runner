Public Class Form1
    Dim gridSize As Integer = 50 'Amount of rows and columns!
    Dim cellSize As Integer = 10 ' Size of cells!
    Private Panel1 As New Panel()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(10, 10) ' Puts the panels location at this point
        Panel1.Size = New Size(gridSize * cellSize, gridSize * cellSize)
        Me.Controls.Add(Panel1) 'Adds the panel to the form

        For i As Integer = 0 To gridSize - 1
            For j As Integer = 0 To gridSize - 1
                Dim cell As New PictureBox()

                'Cell properties created
                cell.Size = New Size(cellSize, cellSize)
                cell.Location = New Point(j * cellSize, i * cellSize)
                cell.BackColor = Color.DarkSlateGray

                AddHandler cell.BackColorChanged, AddressOf PictureBox_BackColorChanged
                Panel1.Controls.Add(cell)
                FindMiddle(cell)
                CreateExit(cell)
            Next
        Next
    End Sub
    Sub FindMiddle(ByRef cell)
        Dim middle As Integer = (gridSize / 2) - 1 ' Finds the middle

        If cell.Location = New Point(middle * cellSize, middle * cellSize) Then
            cell.BackColor = Color.White 'If the cell is in the middle location it changes the colour to white, this is the starting point
        End If
    End Sub

    Sub CreateExit(ByRef cell)
        Dim random As New Random()
        Dim randNumber As Integer = random.Next(0, gridSize)
        Dim randGridNumber As Integer = random.Next(0, gridSize)
        Dim edgeCoord As Integer = ((randGridNumber) - 1) * randNumber
        Dim edgeCounter As Integer = 0

        For i = 1 To randNumber
            If i = randNumber Then
                If cell.Location.Y = edgeCoord * cellSize Or cell.Location.X = edgeCoord * cellSize Then
                    cell.BackColor = Color.White
                    Exit For
                End If
            End If
        Next
    End Sub
    Private Sub PictureBox_BackColorChanged(control As Object, e As EventArgs)

    End Sub

End Class
