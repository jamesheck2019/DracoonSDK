# DracoonSDK
Dracoon SDK for .NET



# List of functions:
* GetParents
* TestServerConnection
* TestTokenValidation
* LoggedIn
* CreateOAuthClient
* GetOAuthClient
* Search
* SearchRoom
* FilterByExtensions
* FilterByClassifications
* FilterBySize
* SearchByPath
* UserInfo
* AcceptEULA
* RevokeToken
* GetFileDownloadUrl
* FileMetadata
* FolderMetadata
* RoomMetadata
* GetRoomID
* GetFilesDownloadUrlAsZip
* CreateNewFolder
* ListRooms
* ListRoot
* DeleteFile
* DeleteFolder
* DeleteRoom
* DeleteFileFolder
* DeleteMultipleFiles
* DeleteMultipleFolders
* DeleteMultipleFilesFolders
* DeleteMultipleRooms
* RenameFolder
* RenameFile
* ChangeFileClassification
* ChangeFolderClassification
* CreateRoom
* EditRoomNameOrQuota
* AddUserToRoom
* DeleteUserFromRoom
* DeleteMultipleUsersFromRoom
* DownloadFile
* DownloadFileAsStream
* DownloadMultipleFilesAsZip
* GetUploadLink
* UploadLocalFile
* GetHomeRoomSettings
* SetHomeRoomSettings
* CopyFile
* CopyAndRenameFile
* CopyMultipleFiles
* CopyFolder
* CopyAndRenameFolder
* CopyMultipleFolders
* CopyFileFolder
* CopyAndRenameFileFolder
* CopyMultipleFilesFolders
* MoveFile
* MoveAndRenameFile
* MoveMultipleFiles
* MoveFolder
* MoveAndRenameFolder
* MoveMultipleFolders
* MoveFileFolder
* MoveAndRenameFileFolder
* MoveMultipleFilesFolders
* ListTrashedFilesFolders
* EmptyRecycleBin
* Bookmark
* UnBookmark
* ListBookmarks
* ListShares
* ShareFileFolder
* UnShareFileFolder
* ShareInfo


# Code simple:
**get token**
```vb
Dim tkn = Await DracoonSDK.GetToken.GetToken("user", "pass")
```
**set client**
```vb
Dim Clnt As DracoonSDK.IClient = New DracoonSDK.DClient(tkn.token)
```
**list rooms**
```vb.net
Dim RSLT = Await CLNT.ListRooms(20, 0, SortEnum.size, OrderEnum.asc)
For Each onz In RSLT.RoomsList
    DataGridView1.Rows.Add(onz.name, onz.id)
Next
```
**list root files/folders**
```vb
Dim TheFilter As New DracoonSDK.DClient.List_root_Filtering
TheFilter.type.FilesFolders = FilesFoldersEnum.both
Dim RSLT = Await CLNT.ListRoot(TheFilter, T_RootID.Text, 20, 0, SortEnum.size, OrderEnum.asc)
For Each onz In RSLT.itemsList
    DataGridView1.Rows.Add(onz.name, onz.File_Folder.ToString, ConvSize(onz.size), onz.id)
Next
```
**upload local file (without progress tracking)**
```vb.net
Dim UploadCancellationToken As New Threading.CancellationTokenSource()
Dim RSLT = Await CLNT.UploadLocalFile("C:\ureWiz.png", 7992368, ClassificationEnum.Public, UploadTypes.FilePath, "ureWiz.png", nothing, UploadCancellationToken.Token)
```
**upload local file with progress tracking**
```vb.net
Dim UploadCancellationToken As New Threading.CancellationTokenSource()
Dim prog_ReportCls As New Progress(Of MediafireSDK.ReportStatus)(Sub(ReportClass As MediafireSDK.ReportStatus)
                   Label1.Text = String.Format("{0}/{1}", (ReportClass.BytesTransferred), (ReportClass.TotalBytes))
                   ProgressBar1.Value = CInt(ReportClass.ProgressPercentage)
                   Label2.Text = CStr(ReportClass.TextStatus)
                   End Sub)
Dim RSLT = Await CLNT.UploadLocalFile("C:\ureWiz.png", folderid, ClassificationEnum.Public, UploadTypes.FilePath, "ureWiz.png", prog_ReportCls , UploadCancellationToken.Token)
```
