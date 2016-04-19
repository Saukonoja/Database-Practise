<?php
session_start();

if (isset($_POST['search'])){
   	$search = '%'.$_POST['search'].'%';
}

if ($_SESSION['current'] == 'Artists'){
    include("Search-Artists.php");
}

if ($_SESSION['current'] == 'Albums'){
    include("Search-Albums.php");
}

if ($_SESSION['current'] == 'Tracks'){
    include("Search-Tracks.php");
}

if ($_SESSION['current'] == 'Genres'){
    include("Search-Genres.php");
}

if ($_SESSION['current'] == 'Companies'){
    include("Search-Companies.php");
}


?>