<?php
session_start();

include("../Init/config.php");

if (isset($_POST['search'])){
   	$search1 = '%'.$_POST['search'].'%';
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


?>