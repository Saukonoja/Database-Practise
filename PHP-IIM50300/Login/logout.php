<body style="background: gray">

<?php 
session_start();
include("../Init/config.php"); 
        $_SESSION['islogged'] = false;
        $_SESSION['username'] = '';
        echo "<h2 style='text-align:center;'>Logging out...</h2>";
        echo "<script>setTimeout(\"location.href = '".$loginForm."';\",1000);</script>";
?>

</body> 
