<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}
require_once("db-init-music.php");

include("select-queries/search-all-artists-query.php");

include("artists-table.php");

if ($_SESSION['islogged']==true){
   ?>
   <script type="text/javascript">document.getElementById('btnAdd').style.display = 'default';</script>
   <?php
}
else {
?>
    <script type="text/javascript">document.getElementById('btnAdd').style.display = 'none';</script>
<?php
}

include("footer.php");
?>