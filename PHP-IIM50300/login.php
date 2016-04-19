<?php  
session_start();

$errmsg = '';
if(isset($_SESSION['errmsg'])){
        echo $_SESSION['errmsg'];
        unset ($_SESSION['errmsg']);
}
 
if (isset($_POST['username']) AND isset($_POST['password'])) {
require_once("db-init-music.php");

require_once 'Hash.class.php';
   $verify = new Hash();
   $username = $_POST['username'];
   $password = $_POST['password'];
   

   $sql = "SELECT salasana 
            FROM user
            WHERE tunnus = ?";

            $passResult = $conn->prepare($sql);
            $passResult->bind_param('s', $username);
            $passResult->execute();
            $passResult->bind_result($dbpassword);
            if($passResult->fetch()){
                $dbpassword;
            }
            $passResult->close();
            
            if($verify->verifyPasword($password, $dbpassword)){


   $sql1 = "SELECT tyyppi
            FROM user
            WHERE tunnus = ? AND salasana = ?";
      
        
        $result = $conn->prepare("$sql1");        
        $result->bind_param('ss', $username, $dbpassword);
        $result->bind_result($usertype);
            

    if ($result->execute()) {
  
        $_SESSION['islogged'] = true;
        $_SESSION['username'] = $_POST['username'];
        if($result->fetch()){
            $_SESSION['userType'] = $usertype;
        }
        echo "<h2>Logging in...</h2>";
        echo "<script>setTimeout(\"location.href = 'index.php';\",1000);</script>";
    } else {
        $errmsg = '<span style="background: yellow;">Ei oo oo yks</span>';
    }
}else
  $errmsg = '<span style="background: yellow;">Tunnus/Salasana vaarin!</span>';
}
?>  
<?php
if ($errmsg != '')echo $errmsg;
?>

