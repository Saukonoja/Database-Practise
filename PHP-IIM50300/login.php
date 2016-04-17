
﻿<?php
  
session_start();
include("login-form.php");
  
$errmsg = '';
if(isset($_SESSION['errmsg'])){
        echo $_SESSION['errmsg'];
        unset ($_SESSION['errmsg']);
}
 
if (isset($_POST['uid']) AND isset($_POST['passwd'])) {
require_once("/home/H3694/php-dbconfig/db-init.php");

 
   $uid = $_POST['uid'];
   $passwd = $_POST['passwd'];
  
   $sql = "SELECT tunnus, salasana
            FROM user
            WHERE tunnus = :tunnus AND salasana = :salasana";
      
    $stmt = $db->prepare($sql);
    $stmt->execute(array($uid));
      
    if ($stmt->rowCount() == 1) {
  
        $_SESSION['app2_islogged'] = true;
        $_SESSION['uid'] = $_POST['uid'];
         header("Location: http://" . $_SERVER['HTTP_HOST']
                                    . dirname($_SERVER['PHP_SELF']) . '/'
                                    . "index.php");
        exit;
    } else {
        $errmsg = '<span style="background: yellow;">Tunnus/Salasana vaarin!</span>';
    }
}
?>
  
<title>Kirjautusmislomake</title>
  
<?php
if ($errmsg != '')echo $errmsg;
?>

