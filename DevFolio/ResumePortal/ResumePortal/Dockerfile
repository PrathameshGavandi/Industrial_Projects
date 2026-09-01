# Step 1: Build using official OpenJDK 25 image (Nightly/Early Access supported via eclipse-temurin)
FROM maven:3.9.9-eclipse-temurin-21 AS build
# Java 25 चे टूल्स आणि कंपायलर मॅन्युअली ॲड करूया जेणेकरून मेव्हेन एरर देणार नाही
COPY --from=eclipse-temurin:25-jdk-noble /opt/java/openjdk /opt/java/openjdk
ENV JAVA_HOME=/opt/java/openjdk
ENV PATH="${JAVA_HOME}/bin:${PATH}"

COPY . .
RUN mvn clean package -DskipTests

# Step 2: Run using official Java 25 Runtime
FROM eclipse-temurin:25-jre-noble
COPY --from=build /target/*.jar app.jar
EXPOSE 8080
ENTRYPOINT ["java", "-Dspring.profiles.active=prod", "-jar", "app.jar"]
