<?php


//ROOT
$root = "http://student.labranet.jamk.fi/~H3298/iim50300/Music-database/";


$index = $root."index.php";
$about = $root."About/About.php";
$footer = "../Init/footer.php";
$dbInit = "../Init/db-init-music.php";
$sortLink = "../Init/sort.php";
$style =  $root."Style/style.css";

$searchLink = $root."Init/Search.php";


$loginForm = $root."Login/login-form.php";
$registerForm = $root."Register/register-form.php";
$logout = $root."Login/logout.php";
$hashClass = "../Register/Hash.class.php";
$validatorClass = "../Register/Validator.class.php";
$passLib = "../Register/PasswordLib.phar";


//ARTIST

$artists = $root."Artist/Artists.php";
$artistPage = $root."Artist/artist-page.php";
$artistTable = "../Artist/artists-table.php";
$artistClass = "../Artist/Artist.class.php";
$artistViewClass = "../Artist/ArtistView.class.php";
$artistSearch = "../Artist/Search-Artists.php";

$allArtistsQuery = "../Queries/Select-queries/all-artists-query.php";
$artistAlbumsQuery = "../Queries/Select-queries/artist-albums-query.php";
$insertArtistQuery = "../Queries/Insert-queries/insert-artist.php";
$updateArtistQuery = "../Queries/Update-queries/update-artist-query.php";
$artistUpdateFormQuery = "../Queries/Select-queries/artist-update-form-query.php";
$deleteArtistQuery = "../Queries/Delete-queries/delete-artist-query.php";
$allArtistsSearchQuery = "../Queries/Select-queries/search-all-artists-query.php";

$addArtist = $root."Artist/add-artist.php";
$addArtistForm = $root."Artist/add-artist-form.php";
$updateArtist = $root."Artist/update-artist.php";
$updateArtistForm = $root."Artist/update-artist-form.php";


//ALBUM

$albums = $root."Album/Albums.php";
$albumPage = $root."Album/album-page.php";
$albumTable = "../Album/albums-table.php";
$albumClass = "../Album/Album.class.php";
$albumViewClass = "../Album/AlbumView.class.php";
$albumSearch = "../Album/Search-Albums.php";

$allAlbumsQuery = "../Queries/Select-queries/all-albums-query.php";
$albumTracksQuery = "../Queries/Select-queries/album-tracks-query.php";
$albumLengthQuery = "../Queries/Select-queries/album-length-query.php";
$trackTubepathQuery = "../Queries/Select-queries/track-tubepath-query.php";
$allAlbumsSearchQuery = "../Queries/Select-queries/search-all-albums-query.php";

$addAlbum = $root."Album/add-album.php";
$addAlbumForm = $root."Album/add-album-form.php";
$updateAlbum = $root."Album/update-album.php";
$updateAlbumForm = $root."Album/update-album-form.php";
$albumUpdateFormQuery = "../Queries/Select-queries/album-update-form-query.php";
$updateAlbumQuery = "../Queries/Update-queries/update-album-query.php";


//TRACK

$tracks = $root."Track/Tracks.php";
$trackTable = "../Track/tracks-table.php";
$trackClass = "../Track/Track.class.php";
$trackSearch = "../Track/Search-Tracks.php";

$allTracksCountQuery = "../Queries/Select-queries/all-tracks-count-query.php";
$allTracksPaginationQuery = "../Queries/Select-queries/all-tracks-pagination-query.php";
$allTracksSearchQuery = "../Queries/Select-queries/search-all-tracks-query.php";
$allTracksQuery = "../Queries/Select-queries/all-tracks-query.php";

$addTrack = $root."Track/add-track.php";
$addTrackForm = $root."Track/add-track-form.php";
$updateTrack = $root."Track/update-track.php";
$updateTrackForm = $root."Track/update-track-form.php";
$trackUpdateFormQuery = "../Queries/Select-queries/track-update-form-query.php";
$updateTrackQuery = "../Queries/Update-queries/update-track-query.php";


//GENRE

$genres = $root."Genre/Genres.php";
$genrePage = $root."Genre/genre-page.php";
$genreTable = "../Genre/genres-table.php";
$genreClass = "../Genre/Genre.class.php";
$genreViewClass = "../Genre/GenreView.class.php";
$genreSearch = "../Genre/Search-Genres.php";

$allGenresQuery = "../Queries/Select-queries/all-genres-query.php";
$allGenresSearchQuery = "../Queries/Select-queries/search-all-genres-query.php";
$genreTracksQuery = "../Queries/Select-queries/genre-tracks-query.php";

$addGenreForm = $root."Genre/add-genre-form.php";
$updateGenreForm = $root."Genre/update-genre-form.php";

//COMPANY

$companies = $root."Company/Companies.php";
$companyPage = $root."Company/company-page.php";
$companyTable = "../Company/companies-table.php";
$companyClass = "../Company/Company.class.php";
$companyViewClass = "../Company/CompanyView.class.php";
$companySearch = "../Company/Search-Companies.php";

$allCompaniesQuery = "../Queries/Select-queries/all-companies-query.php";
$allCompaniesSearchQuery = "../Queries/Select-queries/search-all-companies-query.php";
$companyAlbumsQuery = "../Queries/Select-queries/company-albums-query.php";

$addCompanyForm = $root."Company/add-company-form.php";
$updateCompanyForm = $root."Company/update-company-form.php";


//USER

$users = $root."User/Users.php";
$userClass = "../User/User.class.php";
$changePassword = "../User/change-password.php";

$allUsersQuery = "../Queries/Select-queries/all-users-query.php";
$userUpdateFormQuery = "../Queries/Select-queries/user-update-form-query.php";
$updateUserQuery = "../Queries/Update-queries/update-user-query.php";
$deleteUserQuery = "../Queries/Delete-queries/delete-user-query.php";

$updateUser = $root."User/update-user.php";
$updateUserForm = $root."User/update-user-form.php";

?>