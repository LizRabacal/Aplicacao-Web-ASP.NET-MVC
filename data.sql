CREATE TRIGGER tg_historicoValor
after
update
    on Produto for each row begin if new.PRECO <> old.PRECO then
insert into
    historicoDepreco
values
    (null, now(), new.ID_PRODUTO, old.PRECO, new.PRECO);

end if;

end / / DELIMITER;

DELIMITER / / 
CREATE TRIGGER tg_atualizarEstoque
AFTER
INSERT
    ON ItensVenda FOR EACH ROW BEGIN DECLARE produtoEstoqueAtual INT;

Produto UPDATE Produto SET ESTOQUE = produtoEstoqueAtual - NEW.QUANTIDADE WHERE ID_PRODUTO = NEW.ID_PRODUTO; 
END // DELIMITER ;
 select * from Produto; select * from historicoDepreco;
