
<?php
  
session_start();

$errmsg = '';
if(isset($_SESSION['errmsg'])){
        echo $_SESSION['errmsg'];
        unset ($_SESSION['errmsg']);
}
 
if (isset($_POST['username']) AND isset($_POST['password'])) {
require_once("db-init-music.php");


 
   $username = $_POST['username'];
   $password = $_POST['password'];
  
   $sql = "SELECT tunnus, salasana, tyyppi
            FROM user
            WHERE tunnus = '$username' AND salasana = '$password';";
      
        $result = $conn->query($sql);
      
    if ($result->num_rows == 1) {
  
        $_SESSION['islogged'] = true;
        $_SESSION['username'] = $_POST['username'];
        if($row = $result->fetch_assoc()){
            $_SESSION['userType'] = $row['tyyppi'];
        }
        echo "<h2>Logging in...</h2>";
        echo "<script>setTimeout(\"location.href = 'index.php';\",1000);</script>";
    } else {
        $errmsg = '<span style="background: yellow;">Tunnus/Salasana vaarin!</span>';
    }
}
?>  
<?php
if ($errmsg != '')echo $errmsg;
?>

