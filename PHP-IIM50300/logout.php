<?php 
session_start(); 
        $_SESSION['islogged'] = false;
        $_SESSION['username'] = '';
        echo "<h2>Logging out...</h2>";
        echo "<script>setTimeout(\"location.href = 'index.php';\",1000);</script>";
?>  
