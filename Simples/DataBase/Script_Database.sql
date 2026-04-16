Create Database WebForm;
Use WebForm;

CREATE TABLE qualificacao (
  CODIGO int NOT NULL AUTO_INCREMENT,
  EMPRESA int DEFAULT NULL,
  DESCRICAO varchar(100) DEFAULT NULL,
  PRIMARY KEY (CODIGO)
);

INSERT INTO qualificacao VALUES (1,1,'QUALIFICAÇÃO 1');
INSERT INTO qualificacao VALUES (2,1,'QUALIFICAÇÃO 2');
INSERT INTO qualificacao VALUES (3,1,'QUALIFICAÇÃO 3');

CREATE TABLE pessoas (
  CODIGO int NOT NULL AUTO_INCREMENT,
  EMPRESA int DEFAULT NULL,
  QUALIFICACAO int DEFAULT NULL,
  NOME varchar(100) DEFAULT NULL,
  EMAIL varchar(100) DEFAULT NULL,
  CNPJ varchar(18) DEFAULT NULL,
  ENDERECO varchar(200) DEFAULT NULL,
  NUMERO varchar(6) DEFAULT NULL,
  COMPLEMENTO varchar(100) DEFAULT NULL,
  BAIRRO varchar(60) DEFAULT NULL,
  CIDADE varchar(60) DEFAULT NULL,
  CEP varchar(10) DEFAULT NULL,
  PAIS varchar(20) DEFAULT NULL,
  TELEFONE varchar(15) DEFAULT NULL,
  CELULAR varchar(15) DEFAULT NULL,
  NOMEFOTO varchar(1000) DEFAULT NULL,
  CAMINHO varchar(1000) DEFAULT NULL,
  FOTO blob,
  PRIMARY KEY (CODIGO),
  KEY FK_CODIGOQUALIFICACAO_idx (QUALIFICACAO),
  CONSTRAINT FK_PESSOAS_QUALIFICACAO_CODIGO FOREIGN KEY (QUALIFICACAO) REFERENCES QUALIFICACAO (CODIGO)
);

INSERT INTO pessoas VALUES (1,1,1,'Pessoa 1','email@email.com','00.000.000/0000-00','','','','Bairro','','','Brasil','(99)9999-9999','(99)99999-9999','account_drop_bg.gif','image/gif',_binary 'GIF89aª\0¥\0\Ä\0\0”””eeeuuu¼¼¼õõõ£££\\\\\\\Õ\Õ\Õ\Ä\Ä\Äûûû\Û\Û\Û\ã\ã\ã\ï\ï\ï\Ð\Ð\ÐWWW;;;CCCDDDBBBEEEFFFHHHKKKGGGPPPLLLJJJMMMIIINNNÿÿÿAAA,\0\0\0\0ª\0¥\0\0ÿ`4dižhª®l\ë¾p,\ÇQm\ßx®\ï|\ïÿÀ pH$BŽÈ¤r\Él:ŸÐ¨tJ­Z­’¬v\Ë\íz¿\à°xL.›\Ïhôg\Ín»\ßð¸|N¯\Û\ïø¼~\Ï\ïûÿ€‚ƒ„…†‡ˆ‰Š‹ŒŽ‘’“”•–—˜™š›œžŸ ¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁ\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ë\Ì\Í\Î\Ï\Ð\Ñ\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\Û\Ü\Ý\Þ\ß\à\á\â\ã\ä\å\æ\ç\è\é\ê\ë\ì\í\î\ïðñòóôõö÷øùúûüýþÿ\0\nH° Áƒ*\\È°¡Ã‡#JœH±¢Å‹3j\ÜÈ±£Ç CŠI²¤É“(Sÿª\\É²¥Ë—0cÊœI³¦Í›8s\ê\ÜÉ³§ÏŸ@_¥J´¨Ñ£H“*]Ê´©S¦W¢JJµªÕ«X³j\Ý\ÊUk‘¯`ÃŠK¶¬Ù³hÓªE;£­Û·p\ãÊK·®Ý»x\íR\ØË·¯ß¿€L¸°\áÃˆ+^Ì¸±\ãÇ#KF|¡²\åË˜3k\ÞÌ¹³\çÏ C‹Mšt…Ó¨S«^Íºµ\ë×°cËžM»¶\íÛ¸s\ë\ÞÍ»·o\Ú‚N¼¸ñ\ãÈ“+_Î¼¹ó\çÐ¡k˜N½ºõ\ëØ³k\ßÎ½»÷\ï\àÃ‹o¡¼ùó\èÓ«_Ï¾½û÷ð\ãËŸO¿¾ýûøó\ë\ß\Ï_~†ÿ\0(\à€h\à&¨\àg‚6è ƒD(\á„Vh\á…f¨\á†v\è\á‡ ‚\ØÁˆ$–h\â‰(¦¨\âŠ,¶\è\â‹0\Æ(\ãŒ4\Öh\ã8\æ¨#Œô\è\ã@)\äDi\ä‘H&©\ä’L6\é\ä“PF)\å”TVi\å•Xf©e’!\0\0;');
INSERT INTO pessoas VALUES (2,1,3,'Pessoa 2','email2@email.com','99.999.999/9999-99',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'(99)9999-9999','(99)99999-9999','upload_file.gif','image/gif',_binary 'GIF89aN\0\0\Ä\0\0\â\â\â|||tttiiióóóaaarrr{{{nnneee\×\××†††zzz^^^žžž\Ì\Ì\Ìkkk–––\Ô\Ô\Ô\Â\ÂÂššš\Ö\ÖÖ½½½±±±¦¦¦vvvpppxxxgggÿÿÿ}}},\0\0\0\0N\0\0\0ÿ \'Ž\Ù2thª®lë¾°;,\Ùh\Ë\Æ_\ïÿÀ pH,œÍ‚`ó4Æ¨tJý\Z¶Ì¦\Ê\íz?›š¨Áùš\ÏCV4\à¡\ß\èÀ`Ô\Û\Ïú}\ßÍ‹\ê|R~€‚‡C„†E\Z\Z’\Z—Ž”–Ÿ£‘UŠR\ZJ‘\0\0•™ÀŽ’Á•nƒzQ°´¼Ú··²åº²\Ý\È;T«Î‘°3	¼8÷\0\×L2Ì«@\á‚\×(ˆ€à¡‚ŽeQ\Þ\á\àŠj\n\0@¦@\Ç<P( PB	@õzH\rƒƒ5@4\"±E\r°Rb|IÀƒ>ð*\0TCœ\n<\Ø(¢À‹9³HM\" \åL°@ÏŸP‡=J«\0B:…*µ\áCwÍŒÐ°‹\0Ê’\Z=Hð\æñ[È‘%\Ô+Æ¼\ØU%rõ\È3ùô	¼wVŸ	^óþIž‡a¡‡=?€¶8Q\Ü\"<+\'‹›\×´±Þ–m¶9Öµ¡¥‚ûgJ€F\Â&\Õ\Õ˜¤aÁ)?n©´\éÞˆ¢i,ý¡6g>iw=€\à1eªGWCb‹xDal<9/\èJ\rt°·“¤“&J\Ä\ØÏ¿¿ÿbx\0;');