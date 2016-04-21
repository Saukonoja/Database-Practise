<?php

$sort_order = 'asc';  
    if (isset($_GET['sort_by']))  
    {  
        if ($_GET['sort_by'] == 'asc')  {  
            $sort_order = 'desc';  
        } else {  
            $sort_order = 'asc';  
        }  
    }  

?>