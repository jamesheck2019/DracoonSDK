Imports DracoonSDK.JSON

Public Interface IClient

    Function GetParents(DestinationFileFolderID As Integer) As Task(Of JSON_GetParents)
    Function TestServerConnection() As Task(Of Boolean)
    Function TestTokenValidation() As Task(Of Boolean)







    Function LoggedIn() As Boolean
    Function CreateOAuthClient(ClientName As String, RedirectUrl As String) As Task(Of JSON_CreateOAuthClient)
    Function GetOAuthClient() As Task(Of JSON_CreateOAuthClient)

    
    
    Function Search(SearchKeywords As String, FolderID As Integer, SubDepthLevel As Integer, Optional SearchFiltering As DClient.Search_Filtering = Nothing, Optional Limit As Integer = 50, Optional Offset As Integer = 0, Optional SortBy As DrAutilities.SortEnum? = Nothing, Optional Order As DrAutilities.OrderEnum? = Nothing) As Task(Of JSON_ListRoot)
    Function SearchRoom(RoomID As Integer, SearchKeywords As String, SearchType As DrAutilities.FilesFoldersEnum, SubDepthLevel As Integer, Optional Limit As Integer = 50, Optional Offset As Integer = 0, Optional SortBy As DrAutilities.SortEnum? = Nothing, Optional Order As DrAutilities.OrderEnum? = Nothing) As Task(Of JSON_ListRoot)
    Function FilterByExtensions(FolderID As Integer, Extension As String, Formula As DrAutilities.FormulaEnum, SubDepthLevel As Integer, Optional Limit As Integer = 50, Optional Offset As Integer = 0, Optional SortBy As DrAutilities.SortEnum? = Nothing, Optional Order As DrAutilities.OrderEnum? = Nothing) As Task(Of JSON_ListRoot)
    Function FilterByClassifications(FolderID As Integer, SearchType As DrAutilities.FilesFoldersEnum, Classification As DrAutilities.ClassificationEnum, SubDepthLevel As Integer, Optional Limit As Integer = 50, Optional Offset As Integer = 0, Optional SortBy As DrAutilities.SortEnum? = Nothing, Optional Order As DrAutilities.OrderEnum? = Nothing) As Task(Of JSON_ListRoot)
    Function FilterBySize(FolderID As Integer, SearchType As DrAutilities.FilesFoldersEnum, SizeinByte As Integer, Symbols As DrAutilities.SymbolsEnum, SubDepthLevel As Integer, Optional Limit As Integer = 50, Optional Offset As Integer = 0, Optional SortBy As DrAutilities.SortEnum? = Nothing, Optional Order As DrAutilities.OrderEnum? = Nothing) As Task(Of JSON_ListRoot)
    Function SearchByPath(FolderID As Integer, SearchType As DrAutilities.FilesFoldersEnum, PathKeywords As String, Formula As DrAutilities.FormulaEnum, SubDepthLevel As Integer, Optional Limit As Integer = 50, Optional Offset As Integer = 0, Optional SortBy As DrAutilities.SortEnum? = Nothing, Optional Order As DrAutilities.OrderEnum? = Nothing) As Task(Of JSON_ListRoot)


    Function UserInfo() As Task(Of JSON_UserInfo)
    Function RevokeToken() As Task(Of Boolean)
    Function GetFileDownloadUrl(FileID As Integer) As Task(Of JSON_GetFileDownloadUrl)
    Function FileMetadata(FileID As Integer) As Task(Of JSON_FileMetadata)
    Function FolderMetadata(FolderID As Integer) As Task(Of JSON_FolderMetadata)
    Function RoomMetadata(RoomID As Integer) As Task(Of JSON_RoomMetadata)

    Function GetFilesDownloadUrlAsZip(NodesIDs As List(Of Integer)) As Task(Of JSON_GetFileDownloadUrl)

    Function CreateNewFolder(DestinationFolderID As Integer, FolderName As String) As Task(Of JSON_CreateNewFolder)
    Function ListRooms(Optional Limit As Integer = 50, Optional Offset As Integer = 0, Optional SortBy As DrAutilities.SortEnum? = Nothing, Optional Order As DrAutilities.OrderEnum? = Nothing) As Task(Of JSON_ListRooms)
    Function ListRoot(ListrootFiltering As DClient.List_root_Filtering, Optional RoomFileFolderID As String = Nothing, Optional Limit As Integer = 50, Optional Offset As Integer = 0, Optional SortBy As DrAutilities.SortEnum? = Nothing, Optional Order As DrAutilities.OrderEnum? = Nothing) As Task(Of JSON_ListRoot)



    Function DeleteFile(FileID As Integer) As Task(Of JSON_DeleteFile)
    Function DeleteFolder(FolderID As Integer) As Task(Of JSON_DeleteFile)
    Function DeleteRoom(RoomID As Integer) As Task(Of JSON_DeleteFile)
    Function DeleteFileFolder(FileFolderID As Integer) As Task(Of JSON_DeleteFile)
    Function DeleteMultipleFiles(FilesIDs As List(Of Integer)) As Task(Of JSON_DeleteFile)
    Function DeleteMultipleFolders(FoldersIDs As List(Of Integer)) As Task(Of JSON_DeleteFile)
    Function DeleteMultipleFilesFolders(FilesFoldersIDs As List(Of Integer)) As Task(Of JSON_DeleteFile)
    Function DeleteMultipleRooms(RoomsIDs As List(Of Integer)) As Task(Of JSON_DeleteFile)

    Function RenameFolder(FolderID As Integer, NewName As String) As Task(Of JSON_FolderMetadata)
    Function RenameFile(FileID As Integer, NewName As String) As Task(Of JSON_FileMetadata)

    Function ChangeFileClassification(FileID As Integer, Classification As DrAutilities.ClassificationEnum) As Task(Of JSON_FileMetadata)
    Function ChangeFolderClassification(FolderID As Integer, Classification As DrAutilities.ClassificationEnum) As Task(Of JSON_FolderMetadata)


    Function CreateRoom(RoomName As String, Permissions As DrAutilities.ClassificationEnum, AdminUserID As Integer) As Task(Of JSON_RoomMetadata)
    Function EditRoomNameOrQuota(RoomID As Integer, Optional NewName As String = Nothing, Optional Quota As Integer? = Nothing) As Task(Of JSON_RoomMetadata)
    Function AddUserToRoom(RoomID As Integer, UserID As Integer, SetPermissions As JSON_Permissions) As Task(Of JSON_DeleteFile)
    Function DeleteUserFromRoom(RoomID As Integer, UserID As Integer) As Task(Of JSON_DeleteFile)
    Function DeleteMultipleUsersFromRoom(RoomID As Integer, UsersIDs As List(Of Integer)) As Task(Of JSON_DeleteFile)

    Function DownloadFile(FileID As String, FileSaveDir As String, FileName As String, Optional ReportCls As IProgress(Of ReportStatus) = Nothing, Optional _proxi As ProxyConfig = Nothing, Optional TimeOut As Integer = 60, Optional token As Threading.CancellationToken = Nothing) As Task
    Function DownloadFileAsStream(FileID As String, Optional ReportCls As IProgress(Of ReportStatus) = Nothing, Optional _proxi As ProxyConfig = Nothing, Optional TimeOut As Integer = 60, Optional token As Threading.CancellationToken = Nothing) As Task(Of IO.Stream)
    Function DownloadMultipleFilesAsZip(NodesIDs As List(Of Integer), FileSaveDir As String, FileName As String, Optional ReportCls As IProgress(Of ReportStatus) = Nothing, Optional _proxi As ProxyConfig = Nothing, Optional TimeOut As Integer = 60, Optional token As Threading.CancellationToken = Nothing) As Task

    Function GetUploadLink(DestinationFolderID As Integer, UploadedName As String, UploadedSize As String, Permissions As DrAutilities.ClassificationEnum) As Task(Of JSON_GetUploadLink)
    Function UploadLocalFile(FileToUpload As Object, DestinationFolderID As String, Permissions As DrAutilities.ClassificationEnum, UploadType As DClient.UploadTypes, FileName As String, Optional ReportCls As IProgress(Of ReportStatus) = Nothing, Optional _proxi As ProxyConfig = Nothing, Optional token As Threading.CancellationToken = Nothing) As Task(Of JSON_FileMetadata)

    Function GetHomeRoomSettings() As Task(Of JSON_GetHomeRoomSettings)
    Function SetHomeRoomSettings(HomeRoomParentName As String, QuotaInBytes As Integer, Active As Boolean) As Task(Of JSON_SetHomeRoomSettings)

    Function CopyFile(SorceFileID As Integer, DestinationFolderID As Integer, Optional RenameTo As String = Nothing, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileMetadata)
    Function CopyAndRenameFile(SorceFileID As Integer, DestinationFolderID As Integer, RenameTo As String, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileMetadata)
    Function CopyMultipleFiles(SorceFilesIDs As List(Of Integer), DestinationFolderID As Integer, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileMetadata)

    Function CopyFolder(SorceFolderID As Integer, DestinationFolderID As Integer, Optional RenameTo As String = Nothing, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FolderMetadata)
    Function CopyAndRenameFolder(SorceFolderID As Integer, DestinationFolderID As Integer, RenameTo As String, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FolderMetadata)
    Function CopyMultipleFolders(SorceFoldersIDs As List(Of Integer), DestinationFolderID As Integer, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FolderMetadata)

    Function CopyFileFolder(SorceFileFolderID As Integer, DestinationFolderID As Integer, Optional RenameTo As String = Nothing, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileFolderMetadata)
    Function CopyAndRenameFileFolder(SorceFileFolderID As Integer, DestinationFolderID As Integer, RenameTo As String, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileFolderMetadata)
    Function CopyMultipleFilesFolders(SorceFilesFoldersIDs As List(Of Integer), DestinationFolderID As Integer, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileFolderMetadata)




    Function MoveFile(SorceFileID As Integer, DestinationFolderID As Integer, Optional RenameTo As String = Nothing, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileMetadata)
    Function MoveAndRenameFile(SorceFileID As Integer, DestinationFolderID As Integer, RenameTo As String, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileMetadata)
    Function MoveMultipleFiles(SorceFilesIDs As List(Of Integer), DestinationFolderID As Integer, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileMetadata)

    Function MoveFolder(SorceFolderID As Integer, DestinationFolderID As Integer, Optional RenameTo As String = Nothing, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FolderMetadata)
    Function MoveAndRenameFolder(SorceFolderID As Integer, DestinationFolderID As Integer, RenameTo As String, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FolderMetadata)
    Function MoveMultipleFolders(SorceFoldersIDs As List(Of Integer), DestinationFolderID As Integer, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FolderMetadata)

    Function MoveFileFolder(SorceFileFolderID As Integer, DestinationFolderID As Integer, Optional RenameTo As String = Nothing, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileFolderMetadata)
    Function MoveAndRenameFileFolder(SorceFileFolderID As Integer, DestinationFolderID As Integer, RenameTo As String, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileFolderMetadata)
    Function MoveMultipleFilesFolders(SorceFilesFoldersIDs As List(Of Integer), DestinationFolderID As Integer, Optional IfAlreadyExist As DrAutilities.ResolutionStrategyEnum? = Nothing) As Task(Of JSON_FileFolderMetadata)


    Function ListTrashedFilesFolders(RoomID As Integer, Optional FilesFolders As DrAutilities.FilesFoldersEnum? = Nothing, Optional containsKeywords As String = Nothing, Optional PathKeywords As String = Nothing, Optional Limit As Integer = 50, Optional Offset As Integer = 0, Optional SortBy As DrAutilities.SortEnum? = Nothing, Optional Order As DrAutilities.OrderEnum? = Nothing) As Task(Of JSON_ListTrashedFilesFolders)
    Function EmptyRecycleBin(RoomID As Integer) As Task(Of JSON_ListTrashedFilesFolders)
    Function Bookmark(ID As Integer) As Task(Of JSON_FileFolderRoomMetadata)
    Function UnBookmark(ID As Integer) As Task(Of JSON_DeleteFile)
    Function ListBookmarks(Optional FilesFolders As DrAutilities.FilesFoldersEnum? = Nothing, Optional Limit As Integer = 50, Optional Offset As Integer = 0, Optional SortBy As DrAutilities.SortEnum? = Nothing, Optional Order As DrAutilities.OrderEnum? = Nothing) As Task(Of JSON_ListFavorite)


    Function ListShares(Optional ListshareFiltering As DClient.List_Shares_Filtering = Nothing, Optional Limit As Integer = 50, Optional Offset As Integer = 0, Optional SortBy As DrAutilities.SortEnum? = Nothing, Optional Order As DrAutilities.OrderEnum? = Nothing) As Task(Of JSON_ListShares)
    Function ShareFileFolder(FileFolderID As Integer, Optional PassWord As String = Nothing, Optional NameShareTo As String = Nothing, Optional MaxShareDownloads As String = Nothing) As Task(Of JSON_SharesItem)
    Function UnShareFileFolder(ShareID As Integer) As Task(Of JSON_DeleteFile)
    Function ShareInfo(ShareID As Integer) As Task(Of JSON_SharesItem)


End Interface
