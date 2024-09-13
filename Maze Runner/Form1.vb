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
                CreateBranches(cell)
            Next
        Next
        CreateExit()
    End Sub

    ' CHanges the middle cell's colour.
    Sub FindMiddle(ByRef cell As PictureBox)
        Dim middle As Integer = (gridSize / 2) - 1 ' Finds the middle
        If cell.Location = New Point(middle * cellSize, middle * cellSize) Then
            cell.BackColor = Color.LightGray ' Middle cell changes color to white
        End If
    End Sub
    Sub CreateBranches(ByRef cell As PictureBox)
        Dim random As New Random()
        Dim randomCoordX As Integer
        Dim randomCoordY As Integer
        Dim counter As Integer = 0

        Do
            randomCoordX = random.Next(0, gridSize - 1) * cellSize
            randomCoordY = random.Next(0, gridSize - 1) * cellSize

            If cell.Location = New Point(randomCoordX, randomCoordY) Then
                cell.BackColor = Color.LightGray
                If CellsOnEdge.Contains(cell) Then
                    cell.BackColor = Color.DarkSlateGray
                End If
            End If
                counter += 1
        Loop Until counter = 12
    End Sub
    ' Changes one of the random cells on the edge.
    Sub CreateExit()
        Dim rand As New Random()
        'Selects a cell randomly from the Cellsonedge list
        Dim randomCellOnEdge As PictureBox = CellsOnEdge(rand.Next(CellsOnEdge.Count))
        randomCellOnEdge.BackColor = Color.LightGray
    End Sub


    Private Sub PictureBox_BackColorChanged(control As Object, e As EventArgs)
        ' If a picturebox's colour is changed, this will react.
    End Sub
End Class
