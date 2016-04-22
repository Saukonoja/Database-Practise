<?php
 
    class Company{
        private $name;
        private $country;
        private $year;
        private $id;
 
        function __construct($name, $country, $year, $id){
            $this->name = $name;
            $this->country = $country;
            $this->year = $year;         
            $this->id = $id;
        }

        function __toString() {
             include ("../Init/config.php");
            if ($_SESSION['islogged'] == true){
                $display = 'display:default;';
            }    
            else{
                $display = 'display:none;';
            }
            return "<tr><td><a href='" . $companyPage . "?link_company=".$this->name."'>" . $this->name. '</a></td>
                        <td id=country>'.$this->country.'</td>
                        <td id=year>'.$this->year.'</td>
                        <td id=\'editTd\'><form method=\'post\' action=\'update-company-form.php\'><button style='. $display .
                        ' id=\'btnEdit\' name=\'ID\' value=' . $this->id . '>Edit</button></form></td></tr>';
        }
    }
 
?>