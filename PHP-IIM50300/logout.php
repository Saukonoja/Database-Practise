<body style="background: gray">

<?php 
session_start(); 
        $_SESSION['islogged'] = false;
        $_SESSION['username'] = '';
        echo "<h2 style='text-align:center;'>Logging out...</h2>";
        echo "<script>setTimeout(\"location.href = 'login-form.php';\",1000);</script>";
?>

</body> 
