--
-- PostgreSQL database dump
--

-- Dumped from database version 15.10
-- Dumped by pg_dump version 15.10 (Homebrew)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: uuid-ossp; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS "uuid-ossp" WITH SCHEMA public;


--
-- Name: EXTENSION "uuid-ossp"; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION "uuid-ossp" IS 'generate universally unique identifiers (UUIDs)';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Fields; Type: TABLE; Schema: public; Owner: scarecrow
--

CREATE TABLE public."Fields" (
    "Id" uuid DEFAULT gen_random_uuid() NOT NULL,
    "FieldName" text NOT NULL,
    "FieldArea" double precision NOT NULL,
    "CropName" text NOT NULL
);


ALTER TABLE public."Fields" OWNER TO scarecrow;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: scarecrow
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO scarecrow;

--
-- Data for Name: Fields; Type: TABLE DATA; Schema: public; Owner: scarecrow
--

COPY public."Fields" ("Id", "FieldName", "FieldArea", "CropName") FROM stdin;
e3ba3806-5e54-44c9-a8ed-cbe6faab71a6	Field A	45	Corn
05674891-03a6-4843-bdea-6f39fc3724f3	Field B	56	Mango
04766bac-3755-4c5e-a77c-d42a0fb899c2	Field C	68	Rice
70758a32-d6c9-4de1-9271-cac9b335d79d	Field E	47	Apple
cc0ad11f-1f2d-4e1c-a956-d6b3d4801b0c	Field D	39	Durian
4d95db54-6294-4d05-9235-82afc7adbd02	Field O	34	Lychee
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: scarecrow
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20241212101318_AddFieldTable	8.0.11
\.


--
-- Name: Fields PK_Fields; Type: CONSTRAINT; Schema: public; Owner: scarecrow
--

ALTER TABLE ONLY public."Fields"
    ADD CONSTRAINT "PK_Fields" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: scarecrow
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- PostgreSQL database dump complete
--

