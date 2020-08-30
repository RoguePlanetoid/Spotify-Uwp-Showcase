# Spotify.Uwp.Showcase

Showcase Application for Spotify API .NET Standard SDK Library for Universal Windows Platform Extensions

![Spotify Showcase](Resources/spotify-showcase.png)

## AddPlaylistDialogViewModel

Add Playlist Dialog View Model

### Constructor(client, response)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| response | *Spotify.NetStandard.Sdk.CurrentUserResponse*<br>Current User Response |

### AddPlaylist(viewModel)

Add Playlist

| Name | Description |
| ---- | ----------- |
| viewModel | *Spotify.Uwp.Showcase.AddPlaylistViewModel*<br>Add Playlist View Model |


## AddPlaylistItemDialogViewModel

Add Playlist Item Dialog View Model

### Constructor(client, playItem)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| playItem | *Spotify.NetStandard.Sdk.IPlayItemResponse*<br>Spotify Track or Episode |

### AddPlaylistItem(playItem)

Add Playlist Item

| Name | Description |
| ---- | ----------- |
| playItem | *Spotify.NetStandard.Sdk.IPlayItemResponse*<br>Track or Episode |

### PlayItem

Play Item

### Playlist

Playlist

### Playlists

Playlists


## AddPlaylistViewModel

Add Playlist View Model

### Constructor(user)

Playlist Details View Model

| Name | Description |
| ---- | ----------- |
| user | *Spotify.NetStandard.Sdk.CurrentUserResponse*<br>Playlist Response |

### Description

Description

### IsCollaborative

Is Collaborative

### IsPublic

Is Public

### Name

Name

### ToAddPlaylistRequest

To Set Playlist Request

#### Returns



### UserId

User Id


## AlbumPageViewModel

Album Page View Model

### Constructor(client, albumId)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| albumId | *System.String*<br>Spotify Album Id |

### Tracks

Tracks


## AlbumsPageViewModel

Albums Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Saved

Saved


## Analysis

Analysis Display

### Constructor

Constructor


## AnalysisItem

Analysis Item

### Constructor(start, duration)

Constructor

| Name | Description |
| ---- | ----------- |
| start | *System.Nullable{System.Single}*<br>Start |
| duration | *System.Nullable{System.Single}*<br>Duration |

### Duration

Duration

### Start

Start

### Spotify.Uwp.Showcase.Analysis.colours

Colours

### Spotify.Uwp.Showcase.Analysis.GetItems(response)

Get Items

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.AudioAnalysisResponse*<br>Audio Analysis Response |

#### Returns

Dictionary of String, List of Analysis Item

### Spotify.Uwp.Showcase.Analysis.Update

Update

### Spotify.Uwp.Showcase.Analysis.Value

Audio Analysis Response

### Spotify.Uwp.Showcase.Analysis.ValueProperty

Value Property


## App

Provides application-specific behavior to supplement the default Application class.

### Constructor

Initializes the singleton application object. This is the first line of authored code executed, and as such is the logical equivalent of main() or WinMain().

### InitializeComponent

InitializeComponent()

### OnLaunched(e)

Invoked when the application is launched normally by the end user. Other entry points will be used such as when the application is launched to open a specific file.

| Name | Description |
| ---- | ----------- |
| e | *Windows.ApplicationModel.Activation.LaunchActivatedEventArgs*<br>Details about the launch request and process. |

### OnNavigationFailed(sender, e)

Invoked when Navigation to a certain page fails

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br>The Frame which failed navigation |
| e | *Windows.UI.Xaml.Navigation.NavigationFailedEventArgs*<br>Details about the navigation failure |

### OnSuspending(sender, e)

Invoked when application execution is being suspended. Application state is saved without knowing whether the application will be terminated or resumed with the contents of memory still intact.

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br>The source of the suspend request. |
| e | *Windows.ApplicationModel.SuspendingEventArgs*<br>Details about the suspend request. |


## AppViewModel

App View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Export

Export

#### Returns

JSON

### Finish

Finish Application

### GetFavourites

Get Favourites

#### Returns

Favourites

### Import(source)

Import

| Name | Description |
| ---- | ----------- |
| source | *System.String*<br>JSON |

### Load(filename)

Load

#### Type Parameters

- TViewModel - ViewModel Type

| Name | Description |
| ---- | ----------- |
| filename | *System.String*<br>Filename |

#### Returns

Result ViewModel

### Save(source, filename)

Save

#### Type Parameters

- TViewModel - ViewModel Type

| Name | Description |
| ---- | ----------- |
| source | Source ViewModel |
| filename | *System.String*<br>Filename |

#### Returns

True on Success, False if Not

### SetFavourites(favourites)

Set Favourites

| Name | Description |
| ---- | ----------- |
| favourites | *Spotify.Uwp.Showcase.Favourites*<br>Favourites |

### Start

Start Application


## ArtistPageViewModel

Artist Page View Model

### Constructor(client, artistId)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| artistId | *System.String*<br>Spotify Artist Id |

### Albums

Albums

### Artists

Related Artists

### Tracks

Top Tracks


## ArtistsPageViewModel

Artists Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Followed

Followed

### Top

Top


## BaseDialogViewModel

Base Dialog View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Client

Spotify Sdk Client

### Dispose

Dispose

### IsPrimaryVisible

Is Primary Visible

### IsSecondaryVisible

Is Secondary Visible

### Loading

Loading Indicator

### PrimaryCommand

Primary Command

### PrimaryLabel

Primary Label

### Result

Result

### SecondaryCommand

Cancel Command

### SecondaryLabel

Secondary Label

### Title

Title


## BaseItemDialogViewModel

Base Item Dialog View Model

### Constructor(client, response)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br> |
| response | Response Type |

### Constructor(client, id)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| id | *System.String*<br>Spotify Item Id |

### Get(id)

Get

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>Id (Optional) |

### GetItemAsync(id)

Get Item Async

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>Id (Optional) |

#### Returns

Response

### Item

Item Response

### Refresh

Refresh


## BaseItemViewModel

Base Item Page View Model

#### Type Parameters

- TResponse - 

### Constructor(client, id)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify SDK Client |
| id | *System.String*<br>Spotify Item Id |

### Get(System.String)

Get

### GetItemAsync(id)

Get Item Async

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br> |

#### Returns



### Item

Item Response

### Refresh

Refresh


## BasePageViewModel

Base Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Client

Spotify Sdk Client

### Dispose

Dispose

### Loading

Loading Indicator

### NavigatePage(response)

Navigate Page Album

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.AlbumResponse*<br>Album Response |

### NavigatePage(response, related)

Navigate Page Artist

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.ArtistResponse*<br>Artist Response |
| related | *System.Boolean*<br>Is Related? |

### NavigatePage(response)

Category Page Album

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.CategoryResponse*<br>Category Response |

### NavigatePage(response)

Navigate Page Current User

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.CurrentUserResponse*<br>Current User Response |

### NavigatePage(response)

Navigate Page Episode

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.EpisodeResponse*<br>Episode Response |

### NavigatePage(response)

Navigate Page Playlist

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |

### NavigatePage(response)

Navigate Page Recommendation

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.RecommendationGenreResponse*<br>Recommendation Genre Response |

### NavigatePage(response)

Navigate Page Show

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.ShowResponse*<br>Show Response |

### NavigatePage(response)

Navigate Page Track

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.TrackResponse*<br>Track Response |

### NavigatePage(response)

Navigate Page User

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.UserResponse*<br>User Response |

### NavigatePage(tag, param, related)

Navigate Page

| Name | Description |
| ---- | ----------- |
| tag | *System.String*<br>Navigate Tag |
| param | *System.Object*<br>Navigate Parameter |
| related | *System.Boolean*<br>Is Related? |


## BooleanToVisibilityConverter

Boolean to Visibility Converter

### Convert(value, targetType, parameter, language)

Convert

| Name | Description |
| ---- | ----------- |
| value | *System.Object*<br> |
| targetType | *System.Type*<br> |
| parameter | *System.Object*<br> |
| language | *System.String*<br> |

#### Returns



### ConvertBack(value, targetType, parameter, language)

Convert Back

| Name | Description |
| ---- | ----------- |
| value | *System.Object*<br> |
| targetType | *System.Type*<br> |
| parameter | *System.Object*<br> |
| language | *System.String*<br> |

#### Returns




## CategoriesPageViewModel

Categories Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Categories

Saved


## CategoryPageViewModel

Category Page View Model

### Constructor(categoryId, client)

Constructor

| Name | Description |
| ---- | ----------- |
| categoryId | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Category Id |
| client | *System.String*<br>Spotify Sdk Client |

### Playlists

Category


## ClearPlaylistDialogViewModel

Clear Playlist Dialog View Model

### Constructor(client, playlist)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| playlist | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Spotify Playlist |

### ClearPlaylist(playlistResponse)

Clear Playlist

| Name | Description |
| ---- | ----------- |
| playlistResponse | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |


## CurrentlyPlayingPageViewModel

Currently Playing Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Devices

Devices

### GetCurrentlyPlaying

Get Currently Playing

### UserPlaybackBackCommand

User Playback Back Command

### UserPlaybackBackHandler(response)

User Playback Back Handler

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.CurrentlyPlayingResponse*<br>Currently Playing Response |

### UserPlaybackForwardCommand

User Playback Forward Command

### UserPlaybackForwardHandler(response)

User Playback Forward Handler

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.CurrentlyPlayingResponse*<br>Currently Playing Response |


## CurrentUserPageViewModel

Current User Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Playlists

Current User Addable


## Dialog

Dialog

### ShowAsync(content, title)

Show

| Name | Description |
| ---- | ----------- |
| content | *System.String*<br>Content |
| title | *System.String*<br>Title |

#### Returns

True When Closed, False if Cancelled


## AddPlaylistItemDialog

Add Playlist Item Dialog

### Constructor

Constructor

### Constructor(playItemResponse)

Constructor

| Name | Description |
| ---- | ----------- |
| playItemResponse | *Spotify.NetStandard.Sdk.IPlayItemResponse*<br>Playlist Response |

### AddPlaylistItem

Add Playlist Item View Model

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()


## ClearPlaylistDialog

Clear Playlist Dialog

### Constructor

Constructor

### Constructor(playlistResponse)

Constructor

| Name | Description |
| ---- | ----------- |
| playlistResponse | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |

### ClearPlaylist

Clear Playlist Dialog View Model

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()


## PlaylistDialog

Playlist Dialog

### Constructor

Constructor

### Constructor(currentUserResponse)

Constructor

| Name | Description |
| ---- | ----------- |
| currentUserResponse | *Spotify.NetStandard.Sdk.CurrentUserResponse*<br>Current User Response |

### Constructor(playlistResponse)

Constructor

| Name | Description |
| ---- | ----------- |
| playlistResponse | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |

### AddPlaylist

Add Playlist Dialog View Model

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### SetPlaylist

Set Playlist Dialog View Model


## SetPlaylistImageDialog

Set Playlist Image Dialog

### Constructor

Constructor

### Constructor(playlistResponse)

Constructor

| Name | Description |
| ---- | ----------- |
| playlistResponse | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()


## Donut

Donut Chart

### Constructor

Constructor

### Fill

Fill

### FillProperty

Fill Property

### GetPath(fill, sweep, hole)

Get Path

| Name | Description |
| ---- | ----------- |
| fill | *Windows.UI.Xaml.Media.Brush*<br>Fill Brush |
| sweep | *System.Double*<br>Sweep Angle |
| hole | *System.Int32*<br>Hole Size |

#### Returns

Path

### GetPoint(angle, hole)

Get Point

| Name | Description |
| ---- | ----------- |
| angle | *System.Double*<br>Angle |
| hole | *System.Int32*<br>Hole |

#### Returns

Point

### Hole

Hole

### HoleProperty

Hold Property

### OnValueChanged(obj, args)

On Value Changed

| Name | Description |
| ---- | ----------- |
| obj | *Windows.UI.Xaml.DependencyObject*<br>Dependency Object |
| args | *Windows.UI.Xaml.DependencyPropertyChangedEventArgs*<br>Dependency Property Changed Event Args |

### Radius

Radius

### RadiusProperty

Radius Property

### Value

Value

### ValueChanged

Value Changed Handler


## ValueChangedHandler

Value Changed Handler

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br>Object |

### Spotify.Uwp.Showcase.Donut.ValueProperty

Value Property


## EpisodePageViewModel

Episode Page View Model

### Constructor(client, episodeId)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| episodeId | *System.String*<br>Spotify Episode Id |

### AddPlaylistItem(response)

Add Playlist Item

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.IPlayItemResponse*<br>Episode |


## Favourites

Favourites

### AlbumIds

Album Spotify Ids

### ArtistIds

Artist Spotify Ids

### EpisodeIds

Show Spotify Ids

### ShowIds

Show Spotify Ids

### TrackIds

Track Spotify Ids


## FavouritesPageViewModel

Favourites Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Albums

Albums

### Artists

Artists

### Episodes

Episodes

### Shows

Shows

### Tracks

Tracks


## FeaturedPageViewModel

Featured Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Featured

Featured Playlists


## FileInfo

File Information

### Constructor(name, content, timestamp)

Constructor

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>File Name |
| content | *System.Byte[]*<br>Byte Content |
| timestamp | *System.Nullable{System.DateTimeOffset}*<br>Time Stamp |

### Constructor(name, content, timestamp)

Constructor

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>File Name |
| content | *System.String*<br>String Content |
| timestamp | *System.Nullable{System.DateTimeOffset}*<br>Time Stamp |

### CreateReadStream

Create Read Stream

#### Returns

Stream

### Exists

Exists

### IsDirectory

Is Directory?

### LastModified

Last Modified Date

### Length

Content Length

### Name

File Name

### PhysicalPath

Physical Path


## FileProvider

File Provider

### Constructor

Constructor

### Constructor(files)

Constructor

| Name | Description |
| ---- | ----------- |
| files | *Microsoft.Extensions.FileProviders.IFileInfo[]*<br>File Info Array |

### Constructor(changeTokens)

Constructor

| Name | Description |
| ---- | ----------- |
| changeTokens | *System.Collections.Generic.KeyValuePair{System.String,Microsoft.Extensions.Primitives.IChangeToken}[]*<br>Change Tokens |

### GetDirectoryContents(subPath)

Get Directory Contents

| Name | Description |
| ---- | ----------- |
| subPath | *System.String*<br>Sub Path |

#### Returns

Directory Contents

### GetFileInfo(subPath)

Get File Information

| Name | Description |
| ---- | ----------- |
| subPath | *System.String*<br>Sub Path |

#### Returns

File Info

### Watch(filter)

Watch

| Name | Description |
| ---- | ----------- |
| filter | *System.String*<br>Filter |

#### Returns

Change Token


## MainPage

Main Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### Item

Main Page View Model

### Navigation_BackRequested(sender, args)

Back Requested

| Name | Description |
| ---- | ----------- |
| sender | *Windows.UI.Xaml.Controls.NavigationView*<br>Navigation View |
| args | *Windows.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs*<br>Navigation View Back Requested Event Args |

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |

### Page_Loaded(sender, e)

Page Loaded

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br>Object |
| e | *Windows.UI.Xaml.RoutedEventArgs*<br>Routed Event Args |

### WebView_NavigationCompleted(sender, args)

Web View Navigated Completed

| Name | Description |
| ---- | ----------- |
| sender | *Windows.UI.Xaml.Controls.WebView*<br>WebView |
| args | *Windows.UI.Xaml.Controls.WebViewNavigationCompletedEventArgs*<br>WebView Navigation Completed Event Args |

### WebView_NavigationStarting(sender, args)

Web View Navigation Starting

| Name | Description |
| ---- | ----------- |
| sender | *Windows.UI.Xaml.Controls.WebView*<br>WebView |
| args | *Windows.UI.Xaml.Controls.WebViewNavigationStartingEventArgs*<br>WebView Navigation Starting Event Args |


## MainPageViewModel

Main Page View Model

### Constructor(client, navigation, content, webView)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| navigation | *Windows.UI.Xaml.Controls.NavigationView*<br>Navigation View |
| content | *Windows.UI.Xaml.Controls.Frame*<br>Content Frame |
| webView | *Windows.UI.Xaml.Controls.WebView*<br>Web View |

### AuthenticationTokenRequiredEventHandler(sender, e)

Token Required Event Handler

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br>Object |
| e | *Spotify.NetStandard.Sdk.AuthenticationTokenRequiredArgs*<br>Token Required Arguments |

### BackInvoked(sender, args)

Back Invoked

| Name | Description |
| ---- | ----------- |
| sender | *Windows.UI.Xaml.Input.KeyboardAccelerator*<br>Keyboard Accelerator |
| args | *Windows.UI.Xaml.Input.KeyboardAcceleratorInvokedEventArgs*<br>Keyboard Accelerator Invoked Event Args |

### BackRequested

Back Requested

#### Returns

True if is, False if Not

### BackRequested(sender, args)

Back Requested

| Name | Description |
| ---- | ----------- |
| sender | *Windows.UI.Xaml.Controls.NavigationView*<br>Navigation View |
| args | *Windows.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs*<br>Navigation View Back Requested Event Args |

### ClientExceptionHandler(sender, e)

Client Exception Handler

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br>Object |
| e | *Spotify.NetStandard.Sdk.ClientExceptionArgs*<br>Client Exception Arguments |

### CurrentlyPlayingItem

Currently Playing

### CurrentUser

Current User

### CurrentUserLogoutCommand

Current User Logout Command

### CurrentUserLogoutHandler(Spotify.NetStandard.Sdk.CurrentUserResponse)

Current User Logout Handler

### Get

Get

### GetCurrentlyPlayingItem

Get Currently Playing

### IsRedirectHost(uri)

Is Redirect Host

| Name | Description |
| ---- | ----------- |
| uri | *System.Uri*<br>Uri |

#### Returns

True if is, False if Not

### ItemInvoked(sender, args)

Item Invoked

| Name | Description |
| ---- | ----------- |
| sender | *Windows.UI.Xaml.Controls.NavigationView*<br>Navigation View |
| args | *Windows.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs*<br>Navigation View Item Invoked Event Args |

### Loaded

Loaded

### Login

Login

#### Returns

Tuple of Success and Error Message (if any)

### Navigate(navigateTag, parameter)

Navigate

| Name | Description |
| ---- | ----------- |
| navigateTag | *System.String*<br>Navigate Tag |
| parameter | *System.Object*<br>Parameter |

### Navigate(navigateTag, transitionInfo)

Navigate

| Name | Description |
| ---- | ----------- |
| navigateTag | *System.String*<br>Navigate Tag |
| transitionInfo | *Windows.UI.Xaml.Media.Animation.NavigationTransitionInfo*<br>Transition Info |

### Navigated(sender, e)

Content Frame Navigated

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br>Object |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |

### NavigateRelated(navigateTag, parameter)

NavigateRelated

| Name | Description |
| ---- | ----------- |
| navigateTag | *System.String*<br>Navigate Tag |
| parameter | *System.Object*<br>Parameter |

### NavigationLoaded(sender, e)

Navigation Loaded

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br>Object |
| e | *Windows.UI.Xaml.RoutedEventArgs*<br>Routed Event Args |

### QuerySubmitted(sender, args)

Search Query Submitted

| Name | Description |
| ---- | ----------- |
| sender | *Windows.UI.Xaml.Controls.AutoSuggestBox*<br>Auto Suggest Box |
| args | *Windows.UI.Xaml.Controls.AutoSuggestBoxQuerySubmittedEventArgs*<br>Auto Suggest Box Query Submitted Event Args |

### ResponseErrorHandler(sender, e)

Response Error Handler

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br>Object |
| e | *Spotify.NetStandard.Sdk.ResponseErrorArgs*<br>Response Error Arguments |

### SetCurrentlyPlayingItem

Set Currently Playing Item

### SetCurrentUser

Set Current User

### ShowDialog(message)

Show Dialog

| Name | Description |
| ---- | ----------- |
| message | *System.String*<br>Message |

#### Returns

True if Dialog Shown, False if Not

### ShowWebViewLogin(showDialog)

Show WebView Login

| Name | Description |
| ---- | ----------- |
| showDialog | *System.Boolean*<br>Show Dialog |

### WebViewNavigationCompleted(webView, args)

Web View Navigation Completed

| Name | Description |
| ---- | ----------- |
| webView | *Windows.UI.Xaml.Controls.WebView*<br>Web View |
| args | *Windows.UI.Xaml.Controls.WebViewNavigationCompletedEventArgs*<br>Web View Navigation Completed Args |

### WebViewNavigationStarting(webView, args)

Web View Navigation Starting

| Name | Description |
| ---- | ----------- |
| webView | *Windows.UI.Xaml.Controls.WebView*<br>Web View |
| args | *Windows.UI.Xaml.Controls.WebViewNavigationStartingEventArgs*<br>Web View Navigation Starting Event Args |

### WebViewUri

Web View Uri

#### Returns

Uri


## NewReleasesPageViewModel

New Releases Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### NewReleases

New Releases


## AlbumPage

Album Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## AlbumsPage

Albums Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## ArtistPage

Artist Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## ArtistsPage

Artists Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## CategoriesPage

Categories Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## CategoryPage

Category Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## CurrentlyPlayingPage

Currently Playing Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## CurrentUserPage

Current User Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## EpisodePage

Episode Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## FavouritesPage

Favourites Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## FeaturedPage

Featured Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## NewReleasesPage

New Releases

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## PlaylistPage

Playlist Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## PlaylistsPage

Playlists Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## RecommendationPage

Recommendation Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## RecommendedPage

Recommended Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## SearchPage

Search Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## ShowPage

Show Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## ShowsPage

Shows Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## TrackPage

Track Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## TracksPage

Tracks Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## UserPage

User Page

### Constructor

Constructor

### Connect(System.Int32,System.Object)

Connect()

### Dispose

Dispose

### GetBindingConnector(System.Int32,System.Object)

GetBindingConnector(int connectionId, object target)

### InitializeComponent

InitializeComponent()

### OnNavigatedTo(e)

OnNavigatedTo

| Name | Description |
| ---- | ----------- |
| e | *Windows.UI.Xaml.Navigation.NavigationEventArgs*<br>Navigation Event Args |


## PlayItemTemplateSelector

Play Item Template Selector

### PlayItemEpisodeTemplate

Episode Template

### PlayItemTrackTemplate

Track Template

### SelectTemplateCore(item, container)

Select Template

| Name | Description |
| ---- | ----------- |
| item | *System.Object*<br>Object |
| container | *Windows.UI.Xaml.DependencyObject*<br>Dependency Object |

#### Returns




## PlaylistItemTemplateSelector

Playlist Item Template Selector

### PlaylistItemEpisodeTemplate

Episode Template

### PlaylistItemTrackTemplate

Track Template

### SelectTemplateCore(item, container)

Select Template

| Name | Description |
| ---- | ----------- |
| item | *System.Object*<br>Object |
| container | *Windows.UI.Xaml.DependencyObject*<br>Dependency Object |

#### Returns

Data Template


## PlaylistPageViewModel

Playlist Page View Model

### Constructor(client, playlistId)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| playlistId | *System.String*<br>Spotify Playlist Id |

### ClearPlaylist(response)

Clear Playlist

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |

### ClearPlaylistCommand

Clear Playlist

### PlaylistItems

Playlist Items

### SetPlaylist(response)

Set Playlist

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |

### SetPlaylistImage(response)

Set Playlist Image

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |


## PlaylistsPageViewModel

Playlists Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### AddPlaylist

Add Playlist

### AddPlaylistCommand

Add Playlist Command

### Playlists

User


## Program

Program class


## RecommendationPageViewModel

Recommendation Page View Model

### Constructor(client, genre)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| genre | *System.String*<br>Genre |

### Item

Genre

### Recommended

Recommended Tracks


## RecommendedPageViewModel

Recommended Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Genres

Genres


## SearchPageViewModel

Search Page View Model

### Constructor(client, value)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| value | *System.String*<br>Search Term |

### Albums

Albums

### Artists

Artists

### Episodes

Episodes

### Playlists

Playlists

### Shows

Shows

### Tracks

Tracks


## SetPlaylistDialogViewModel

Set Playlist Dialog View Model

### Constructor(client, response)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| response | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |

### SetPlaylist(viewModel)

Set Playlist

| Name | Description |
| ---- | ----------- |
| viewModel | *Spotify.Uwp.Showcase.SetPlaylistViewModel*<br>Set Playlist View Model |


## SetPlaylistImageDialogViewModel

Set Playlist Image Dialog View Model

### Constructor(client, response)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| response | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |

### SetPlaylistImage(response)

Set Playlist Image

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.PlaylistImageResponse*<br>Playlist Image Response |


## SetPlaylistViewModel

Set Playlist View Model

### Constructor(playlist)

Playlist Details View Model

| Name | Description |
| ---- | ----------- |
| playlist | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |

### Description

Description

### IsCollaborative

Is Collaborative

### IsPublic

Is Public

### Name

Name

### PlaylistId

Playlist Id

### ToSetPlaylistRequest

To Set Playlist Request

#### Returns




## Settings

Settings

### AddJson(configurationBuilder, filename, settingsJson)

Add Json

| Name | Description |
| ---- | ----------- |
| configurationBuilder | *Microsoft.Extensions.Configuration.IConfigurationBuilder*<br>Configuration Builder |
| filename | *System.String*<br>Filename |
| settingsJson | *System.String*<br>Settings JSON |

#### Returns

Configuration Builder

### GetAppSettings

Get App Settings

#### Returns

IConfiguration

### GetAppxJson(filename)

Get Appx Json

| Name | Description |
| ---- | ----------- |
| filename | *System.String*<br>Filename |

#### Returns

Settings JSON


## ShowPageViewModel

Show Page View Model

### Constructor(client, showId)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| showId | *System.String*<br>Spotify Show Id |

### Episodes

Episodes


## ShowsPageViewModel

Shows Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Saved

Saved


## Slider

Bindable Slider

### Constructor

Bindable Slider

### BindableSlider_ManipulationCompleted(sender, e)

Slider Manipulation Completed

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br>Slider |
| e | *Windows.UI.Xaml.Input.ManipulationCompletedRoutedEventArgs*<br>Manipulation Starting Routed Event Args |

### BindableSlider_ManipulationStarting(sender, e)

Slider Manipulation Starting

| Name | Description |
| ---- | ----------- |
| sender | *System.Object*<br>Slider |
| e | *Windows.UI.Xaml.Input.ManipulationStartingRoutedEventArgs*<br>Manipulation Starting Routed Event Args |

### Current

Current

### CurrentProperty

Current

### Update(value)

Update

| Name | Description |
| ---- | ----------- |
| value | *System.Object*<br>Value |

### ValueChangedCommand

Value Changed Command

### ValueChangedCommandProperty

Value Changed Command


## SpotifySdk

Spotify Sdk Singleton

### Constructor

Constructor

### Client

Spotify Sdk Client

### Init

Init

### Instance

Spotify Sdk Client Instance


## StringFormatConverter

String Format Convertor

### Convert(value, targetType, parameter, language)

Convert

| Name | Description |
| ---- | ----------- |
| value | *System.Object*<br> |
| targetType | *System.Type*<br> |
| parameter | *System.Object*<br> |
| language | *System.String*<br> |

#### Returns



### ConvertBack(value, targetType, parameter, language)

Convert Back

| Name | Description |
| ---- | ----------- |
| value | *System.Object*<br> |
| targetType | *System.Type*<br> |
| parameter | *System.Object*<br> |
| language | *System.String*<br> |

#### Returns




## TrackPageViewModel

Track Page View Model

### Constructor(client, trackId)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |
| trackId | *System.String*<br>Spotify Track Id |

### AddPlaylistItem(response)

Add Playlist Item

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.IPlayItemResponse*<br>Track or Episode |


## TracksPageViewModel

Tracks Page View Model

### Constructor(client)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify Sdk Client |

### Recent

Recent Tracks

### Saved

Saved Tracks

### Top

Top Tracks


## UserPageViewModel

User Page View Model

### Constructor(client, userId)

Constructor

| Name | Description |
| ---- | ----------- |
| client | *Spotify.NetStandard.Sdk.ISpotifySdkClient*<br>Spotify SDK Client |
| userId | *System.String*<br>User Id |

### Playlists

User