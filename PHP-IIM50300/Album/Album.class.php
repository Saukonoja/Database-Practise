<?php
 
    class Album{
        private $name;
        private $artist;
        private $year;
        private $company;
        private $id;
 
        function __construct($name, $artist, $year, $company, $id){
            $this->name = $name;
            $this->artist = $artist;
            $this->year = $year;
            $this->company = $company;
            $this->id = $id;
        }

        function __toString() {
        include("../Init/config.php");

        if ($_SESSION['islogged'] == true){
            $display = 'display:default;';
        }    
        else{
            $display = 'display:none;';
        }
            return "<tr><td><a href='" . $albumPage . "?link_album=".$this->name."'>" . $this->name. "</a></td><td><a href='" . $artistPage . "?link_artist=".$this->artist."'>" . $this->artist. '</a></td>
                        <td id=year>'. $this->year . "</td><td><a href='" . $companyPage . "?link_company=".$this->company."'>" . $this->company. '</a></td><td id=\'editTd\'>
                        <form method=\'post\' action='.$updateAlbumForm.'><button style='. $display . ' id=\'btnEdit\' name=\'ID\' value=' . $this->id . '>Edit</button></form></td></tr>';
        }
    }
 
?>