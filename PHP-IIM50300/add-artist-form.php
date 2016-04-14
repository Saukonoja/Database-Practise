<?php include ("header.php"); ?>

<em>Add artist</em><form method='post' action='update-artist.php'>
<table border='0' cellpadding='5'>
<tr valign='top'>
  <td align='right'>Name</td>
  <td><input type='text' name='nimi' size='30' value=''></td>
</tr>
<tr valign='top'>
  <td align='right'>Year</td>
  <td><input type='text' name='vuosi' size='30' value=''></td>
</tr>
<tr valign='top'>
  <td align='right'>Country</td>
  <td><input type='text' name='maa' size='30' value=''></td>
</tr>
</table>
<input type='submit' name='action' value='Save' onclick="javascript: return confirm('Accept add?')"><br>
</form>
<?php include ("footer.php"); ?>