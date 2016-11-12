Imports System.Text
Imports SongsDB

Module Module1

   Sub Main()

      Dim Result As Boolean

      Dim mm As SongsDB.SDBApplication = New SongsDB.SDBApplication()
      Dim sl As SDBSongList = mm.AllVisibleSongList

      Result = LstAlbMus(sl)
      Result = LstAlb(sl)
      Result = LstCurTrk(sl)

   End Sub

   Function LstAlbMus(sl As SDBSongList) As Boolean

      Dim sd As New SDBSongData

      Dim slCnt As Integer = sl.Count - 1
      Dim Idx As Integer

      Dim L3 As String = Nothing

      Console.Clear()
      Console.WriteLine("AlbumArtist-Übersicht")
      Console.WriteLine()

      For Idx = 0 To slCnt

         sd = sl.Item(Idx)

         If L3 <> CStr(sd.AlbumArtistName) Then

            L3 = CStr(sd.AlbumArtistName)
            dspAlbumArtist(sd)

         End If

      Next

      Return True

   End Function

   Function LstAlb(sl As SDBSongList) As Boolean

      Dim sd As New SDBSongData
      Dim sdA As ISDBAlbum

      Dim slCnt As Integer = sl.Count - 1
      Dim Idx As Integer

      Dim L2 As String = Nothing
      Dim L3 As String = Nothing

      Console.Clear()
      Console.WriteLine("Album-Übersicht")
      Console.WriteLine()

      For Idx = 0 To slCnt

         sd = sl.Item(Idx)
         sdA = sd.Album

         If L3 <> CStr(sd.AlbumArtistName) Then

            dspAlbumArtist(sd)

            L3 = CStr(sd.AlbumArtistName)
            L2 = Nothing

         End If

         If L2 <> CStr(sdA.Name) Then

            dspAlbum(sd)

            L2 = CStr(sdA.Name)

         End If
      Next

      Return True

   End Function

   Function LstCurTrk(sl As SDBSongList) As Boolean


      Dim sd As New SDBSongData
      Dim sdA As ISDBAlbum

      Dim slCnt As Integer = sl.Count - 1
      Dim Idx As Integer

      Dim TrackData As New StringBuilder

      Dim L1 As String = Nothing
      Dim L2 As String = Nothing
      Dim L3 As String = Nothing

      Console.Clear()
      Console.WriteLine("Track-Übersicht")
      Console.WriteLine()

      For Idx = 0 To slCnt

         sd = sl.Item(Idx)
         sdA = sd.Album

         If L3 <> CStr(sd.AlbumArtistName) Then

            dspAlbumArtist(sd)

            L3 = CStr(sd.AlbumArtistName)
            L2 = Nothing
            L1 = Nothing

         End If

         If L2 <> CStr(sdA.Name) Then

            dspAlbum(sd)

            L2 = CStr(sdA.Name)
            L1 = Nothing

         End If

         If L1 <> CStr(sd.DiscNumberStr) And L1 <> Nothing Then
            Console.WriteLine()
         End If
         L1 = CStr(sd.DiscNumberStr)

         TrackData.Clear()
         If sd.DiscNumber <> 0 Then
            TrackData.Append(Format(sd.DiscNumber, "00"))
         Else
            TrackData.Append("  ")
         End If

         TrackData.Append(" ")
         TrackData.Append(Format(sd.TrackOrder, "00"))
         TrackData.Append(" ")
         TrackData.Append(sd.SongLengthString)
         TrackData.Append(" ")
         TrackData.Append(sd.Title)
         WrtCnsLin(TrackData)
      Next

      Return True

   End Function

   Function dspAlbumArtist(sd As SDBSongData) As Boolean

      Dim Header As New StringBuilder

      Console.ForegroundColor = ConsoleColor.Yellow
      Console.WriteLine()

      Header.Clear()
      Header.Append(Trim(CStr(sd.AlbumArtistName)))
      WrtCnsLin(Header)

      Console.ForegroundColor = ConsoleColor.White

      Return True

   End Function

   Function dspAlbum(sd As SDBSongData) As Boolean

      Dim Header As New StringBuilder
      Dim sdA As ISDBAlbum = sd.Album

      Console.ForegroundColor = ConsoleColor.Magenta
      Console.WriteLine()

      Header.Clear()
      Header.Append("Album: ")
      Header.Append(Trim(CStr(sdA.Name)))
      WrtCnsLin(Header)

      Header.Clear()
      Header.Append("Erscheinungs-Datum: ")

      If Month(sd.Date) <> 1 And Day(sd.Date) <> 1 Then
         Header.Append(Format(sd.Date, "yyyy-MM-dd"))
      ElseIf Month(sd.Date) <> 1 Then
         Header.Append(Format(sd.Date, "yyyy-MM"))
         Header.Append("   ")
      Else
         Header.Append(Format(sd.Date, "yyyy"))
         Header.Append("      ")
      End If

      WrtCnsLin(Header)

      Console.ForegroundColor = ConsoleColor.White

      Return True

   End Function

   Function WrtCnsLin(InpStr As StringBuilder) As Boolean
      If Console.BufferWidth <= InpStr.Length Then Console.BufferWidth = (InpStr.Length + 1)
      Console.WriteLine(InpStr.ToString)
      Return True
   End Function

End Module