Public Class Form1
    Dim gridSize As Integer = 50 'Amount of rows and columns!
    Dim cellSize As Integer = 10 ' Size of cells!
    Private Panel1 As New Panel()
    Private CellsOnEdge As New List(Of PictureBox) ' List to hold edge cells

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(10, 10) ' Puts the panel's location at this point
        Panel1.Size = New Size(gridSize * cellSize, gridSize * cellSize)
        Me.Controls.Add(Panel1)

        For i As Integer = 0 To gridSize - 1
            For j As Integer = 0 To gridSize - 1
                Dim cell As New PictureBox()

                ' Gives the cells properties
                cell.Size = New Size(cellSize, cellSize)
                cell.Location = New Point(j * cellSize, i * cellSize)
                cell.BackColor = Color.DarkSlateGray

                ' Adds the PictureBox to the panel controls.
                Panel1.Controls.Add(cell)

                ' Add edge cells to the list
                If i = 0 OrElse i = gridSize - 1 OrElse j = 0 OrElse j = gridSize - 1 Then
                    CellsOnEdge.Add(cell)
                End If

                FindMiddle(cell)
            Next
        Next
        CreateExit()
    End Sub

    ' CHanges the middle cell's colour.
    Sub FindMiddle(ByRef cell As PictureBox)
        Dim middle As Integer = (gridSize / 2) - 1 ' Finds the middle
        If cell.Location = New Point(middle * cellSize, middle * cellSize) Then
            cell.BackColor = Color.White ' Middle cell changes color to white
        End If
    End Sub

    ' Changes one of the random cells on the edge.
    Sub CreateExit()
        Dim random As New Random()
        ' Randomly select one cell from the edgeCells list
        Dim randomEdgeCell As PictureBox = CellsOnEdge(random.Next(CellsOnEdge.Count))
        ' Change the selected edge cell's color to white
        randomEdgeCell.BackColor = Color.White
    End Sub

    Private Sub PictureBox_BackColorChanged(control As Object, e As EventArgs)
        ' Handle background color change if necessary
    End Sub
End Class
