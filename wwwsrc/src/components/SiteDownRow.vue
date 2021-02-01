<template>
  <tr>
    <th scope="row">{{ sdProp.siteNum }}</th>
    <td>{{ sdProp.siteName }}</td>
    <td>{{ sdProp.cause }}</td>
    <td>{{ sdProp.solved }}</td>
  </tr>
</template>

<script>
export default {
  name: "SiteDownRow",
  props: ["sdProp"],
};
</script>

<style>
</style>