------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------- AdoNet Connecter ----------------------------------------------------------------------------

// Le mode connecter permet de mettre à jour les données en temps réel, c'est à dire que lorsquon réalise une modification d'une données
// Celle ci est modifier dans la base de donnée
-----------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------- AdoNet Deconnecter ----------------------------------------------------------------------------

// Le mode déconnecter nvoie une image de la base de donnée à un moment donné et peut être modifier par la suite
// On envoie les données modifiées quand on le souhaite
// Ces données sont donc pas mise à jour en temps réel dans la base de données mais se fait lors de l'UPDATE

// 2 types d'objet en monde déconnecter :

// 1/ Le SqlDataAdapter permet d'importer et d'exporter les données 
// Fill permet d'importer les données de la base de données et les stocks dans un DataSet
// UPDATE() permet d'exporter les données du DataSet dans la base de données ne fonction des modifications:
// - Si on ajoute du contenu dans le DataSet, il faut initier l'INSERTCOMMAND
// - Si on modifie du contenu dans le DataSet, il faut initier l'UPDATECOMMAND
// - Si on supprime du contenu dans le DataSet, il faut initier le DELETECOMMAND

// 2/ Le DataSet permet de stocker en local, les données de la base de donnée
// Ces données modifiés ne sont pas mis à jour dans la  base de donnée tant qu'on a pas effectué la commande