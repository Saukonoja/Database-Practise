<?php
<<<<<<< HEAD
include("../Init/header.php");

if (isset($_POST['search'])){
   	$search = '%'.$_POST['search'].'%';
}

if ($_SESSION['current'] == 'Index'){
	header("Location: ". $artists);
=======
session_start();

include("../Init/config.php");

if (isset($_POST['search'])){
   	$search1 = '%'.$_POST['search'].'%';
>>>>>>> timo
}

if ($_SESSION['current'] == 'Artists'){
    include($artistSearch);
}

if ($_SESSION['current'] == 'Albums'){
    include($albumSearch);
}

if ($_SESSION['current'] == 'Tracks'){
    include($trackSearch);
}

if ($_SESSION['current'] == 'Genres'){
    include($genreSearch);
}

if ($_SESSION['current'] == 'Companies'){
    include($companySearch);
}

<<<<<<< HEAD
if ($_SESSION['current'] == 'About'){
	header("Location: ". $artists);
}

if ($_SESSION['current'] == 'Users'){
	header("Location: ". $artists);
}

=======
>>>>>>> timo

?>