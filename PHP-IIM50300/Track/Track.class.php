<?php
 
    class Track{
        private $name;
        private $artist;
        private $album;
        private $year;
 
        function __construct($name, $artist, $album, $year, $id){
            $this->name = $name;
            $this->artist = $artist;
            $this->album = $album;
            $this->year = $year;
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
                return "<tr><td><a href='" . $albumPage . "?link_track=".htmlspecialchars($this->name, ENT_QUOTES)."&link_album=".$this->album."'>".$this->name."</a></td>
                            <td><a href='" . $artistPage . "?link_artist=".$this->artist."'>" . $this->artist."</a></td>
                            <td><a href='" . $albumPage . "?link_album=".$this->album."'>".$this->album.'</td>
                            <td id=year>'.$this->year.'</td><td id=\'editTd\'><form method=\'post\' action='.$updateTrackForm.'><button style='. $display . ' id=\'btnEdit\' name=\'ID\' value=' . $this->id . '>Edit</button></form></td></tr>';      
        }
    }
 
?>