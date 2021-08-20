insert into organization(code , identity_code , name , phone , address ) 
values('221312321s','2132113', 'keysoft.ltd', '024234224242', '2 Ha Yen Trung Hoa , Ha Noi');




insert into profile(fullname , gender , phone , email , address,org_identity_code)
values ('Trinh Ngoc Van' , 'male', '0969947342','cust@keysoft.vn','143 ngu  nhac hoang mai' ,'2132113');
insert into role(name,description,type)
values('ROLE_ADMIN','Quyền quản trị', 'System');

insert into app_group(name , description,enabled,system_group)
values('Administrantion','Quyền quản trị viên', 1,1);
insert into app_user(account_expired,account_locked,credentials_expired,account_enabled,username,password,version,user_level,created_by
,created_date,modified_by,modified_date, password_changed_date,profile_id)
values(0,0,0,1,'cust@keysoft.vn','password',1,0,null,null,null,null,null,1);
select * from group_role ;
select * from app_user ;
select * from app_group;
insert into group_role(group_id,role_id)
values(1,1);
insert into user_role(user_id,role_id)
values(1,1);