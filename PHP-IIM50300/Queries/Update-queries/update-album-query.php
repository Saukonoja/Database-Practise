<?php


$sql= "UPDATE cd 
             SET nimi = ?, 
             yhtio_avain = (SELECT avain FROM yhtio WHERE nimi = ?),
             vuosi_avain = (SELECT avain FROM vuosi WHERE vuosi = ?), 
             kuvapath = ?
             WHERE avain = ?;"

  ?>