<body style="background: gray">

<?php  

session_start();

require_once 'Hash.class.php';
require_once 'Validator.class.php';

require_once("db-init-music.php");
 
if (!empty($_POST['username']) AND !empty($_POST['password'])){
   $validator = new Validator();
   $verify = new Hash();

   $username = isset($_POST['username'])  ? $_POST['username']   : '';
   $password = isset($_POST['password'])  ? $_POST['password']   : '';

    try{
        if ($validator->ValidateLogin($username, $password)){

                $sql1 = 
                "SELECT salasana 
                FROM user
                WHERE tunnus = ?;";

                $passResult = $conn->prepare("$sql1");
                $passResult->bind_param('s', $username);
                $passResult->execute();
                $passResult->bind_result($hash);
                if ($passResult->fetch()){
                    $hash;
                }
                $passResult->close();

                if ($hash != null){
                        if ($verify->verifyPasword($password, $hash)){
                            $sql2 =
                            "SELECT tyyppi
                            FROM user
                            WHERE tunnus = ? AND salasana = ?;";
              
                            $result = $conn->prepare("$sql2");        
                            $result->bind_param('ss', $username, $hash);
                            $result->bind_result($usertype);                

                            if ($result->execute()) {         
                                $_SESSION['islogged'] = true;
                                $_SESSION['username'] = $_POST['username'];
                                if ($result->fetch()){
                                    $_SESSION['userType'] = $usertype;
                                }
                                $result->close();
                                echo "<h2 style='text-align:center;'>Logging in...</h2>";
                                echo "<script>setTimeout(\"location.href = 'index.php';\",1000);</script>"; 
                            }
                        } else {
                            $_SESSION['loginError'] = "Incorrect password.";
                            header("Location : login-form.php"); 
                        }  
                }else{
                    $_SESSION['loginError'] = "Incorrect username.";
                    header("Location : login-form.php"); 
                }
        }else{
            $_SESSION['loginError'] = "Valid username: 5-20 characters.\nValid password: 8-20 characters.\n No special characters.\n";
            header("Location : login-form.php"); 
        }
    }catch (Exception $e){
        echo $e->getMessage();
    } 
}else{
    $_SESSION['loginError'] = "Fill fields first."; 
    header("Location : login-form.php"); 
}

?> 

</body>


