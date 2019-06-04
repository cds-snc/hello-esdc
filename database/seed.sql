CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190603233956_InitialCreate') THEN
    CREATE TABLE "Greetings" (
        "Name" text NOT NULL,
        "Message" text NULL,
        CONSTRAINT "PK_Greetings" PRIMARY KEY ("Name")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190603233956_InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20190603233956_InitialCreate', '2.2.4-servicing-10062');
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190604143550_GreetingGuid') THEN
    ALTER TABLE "Greetings" DROP CONSTRAINT "PK_Greetings";
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190604143550_GreetingGuid') THEN
    ALTER TABLE "Greetings" ALTER COLUMN "Message" TYPE text;
    ALTER TABLE "Greetings" ALTER COLUMN "Message" SET NOT NULL;
    ALTER TABLE "Greetings" ALTER COLUMN "Message" DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190604143550_GreetingGuid') THEN
    ALTER TABLE "Greetings" ADD "Id" uuid NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190604143550_GreetingGuid') THEN
    ALTER TABLE "Greetings" ADD CONSTRAINT "PK_Greetings" PRIMARY KEY ("Id");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190604143550_GreetingGuid') THEN
    CREATE UNIQUE INDEX "IX_Greetings_Name" ON "Greetings" ("Name");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190604143550_GreetingGuid') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20190604143550_GreetingGuid', '2.2.4-servicing-10062');
    END IF;
END $$;
