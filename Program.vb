Imports System

Module Program
    'all Globals
    Public input As String = Console.ReadLine()
    Dim length As String = Len(input)
    Dim wordArray(9) As String
    Dim controlNumber As Integer = 0
    Dim itarator As Integer = 10

    Sub Main(args As String())
        'ass
        Dim dotInString As Boolean = False
        Dim lastisdot As Boolean = False
        If length = 10 Then
            For i = 0 To length - 2
                If input(i) = "X" Then

                ElseIf input(i) = "." Then
                    dotInString = True
                ElseIf IsNumeric(input(i)) = False Then
                    GoTo inputError
                End If
                wordArray(i) = input(i)
            Next
            If input(9) = "." Then
                lastisdot = True
            End If
            If dotInString = True Then '[0:8]
                findMissingNumber()
            ElseIf lastisdot = True Then
                FindLastDot()
            Else
                CalcCorrect()
            End If
        Else
            GoTo inputError
        End If
        Exit Sub
inputError:
        Console.WriteLine("INPUT ERROR")
        Exit Sub
    End Sub
    Sub findMissingNumber()
        'finds the missing number is there is a . in the sequence
        Dim valid As Boolean = False
        Dim looper As Integer = 0
        Do Until valid = True Or looper > 10
            controlNumber = 0
            itarator = 10
            For Each element In wordArray
                If element = "X" Then
                    element = 10
                ElseIf element = "." Then
                    element = CInt(looper)
                Else
                    element = CInt(element)
                End If
                controlNumber += (element * itarator)
                itarator -= 1
            Next
            Dim checkdigit As Integer
            If input(9) = "X" Then
                checkdigit = 10
            Else
                checkdigit = CInt($"{input(9)}") 'WTF
            End If

            If (controlNumber + checkdigit) Mod 11 = 0 Then
                Console.WriteLine($"{looper}")
                valid = True
            End If
            looper += 1
        Loop
    End Sub
    Sub FindLastDot()
        'finds the control number if the last number in the sequence is .
        Dim valid As Boolean = False
        Dim looper As Integer = 0
        Do Until valid = True Or looper > 10
            itarator = 10
            controlNumber = 0
            For Each element In wordArray
                If element = "X" Then
                    element = 10
                Else
                    element = CInt(element)
                End If
                controlNumber += (element * itarator)

                itarator -= 1
            Next
            Dim checkdigit
            checkdigit = looper
            If (controlNumber + checkdigit) Mod 11 = 0 Then

                If checkdigit = 10 Then
                    checkdigit = "X"
                End If
                Console.WriteLine($"{checkdigit}")
                valid = True
            End If
            looper += 1
        Loop

    End Sub
    Sub CalcCorrect()
        '
        Dim itarator As Integer = 10
        Dim wordarray(9) As String
        For Each element In wordarray
            If element = "X" Then
                element = 10
            Else
                element = CInt(element)
            End If
            controlNumber += (element * itarator)
            itarator -= 1
        Next
        Dim checkdigit As Integer
        If input(9) = "X" Then
            checkdigit = 10
        Else
            checkdigit = CInt($"{input(9)}") 'WTF
        End If

        If (controlNumber + checkdigit) Mod 11 = 0 Then
            Console.WriteLine("VALID")
        Else
            Console.WriteLine("INVALID")
        End If
    End Sub
End Module

