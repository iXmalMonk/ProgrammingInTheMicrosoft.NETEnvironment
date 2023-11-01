truncate table net.faculty restart identity cascade;
truncate table net.department restart identity cascade;

drop table if exists net.faculty cascade;
drop table if exists net.department cascade;

drop schema if exists net cascade;